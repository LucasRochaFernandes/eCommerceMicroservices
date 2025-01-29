using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.ProductApi.Infrastructure.Database;
using eCommerce.ProductApi.Infrastructure.Repositories;
using eCommerce.ProductApi.Services;
using eCommerce.ProductApi.Services.Interfaces;
using eCommerce.SharedLibrary.Extensions;
using eCommerce.SharedLibrary.Interfaces;
using MassTransit;

namespace eCommerce.ProductApi.Infrastructure.Extensions;
public static class ProductApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        SharedServiceContainer.AddSharedServices(services, config, "ProductApi-Infra-Logs");

        var rabbitMQHost = Environment.GetEnvironmentVariable("RabbitMQ__Host");

        if (string.IsNullOrEmpty(rabbitMQHost))
        {
            rabbitMQHost = config["RabbitMQ:Host"];
        }
        services.AddMassTransit(busConfig =>
        {
            busConfig.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMQHost, h =>
                {
                    h.Username(config["RabbitMq:Username"]!);
                    h.Password(config["RabbitMq:Password"]!);
                });
                cfg.ConfigureEndpoints(context);
            });

        });

        var redisHost = Environment.GetEnvironmentVariable("Redis__Host");
        if (string.IsNullOrEmpty(redisHost))
        {
            redisHost = "localhost:6379";
        }

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisHost;
            options.InstanceName = "ProductApi";
        });

        services.AddScoped<ICacheService, RedisCacheService>();
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateProductService>();
        services.AddScoped<UpdateProductStockService>();
        services.AddScoped<PubProductCreatedService>();
        services.AddScoped<PubProductStockUpdated>();
        services.AddScoped<GetAllProductsService>();
        services.AddScoped<RemoveProductService>();
        services.AddSingleton<MongoDbService>();
    }

    public static void AddInfrastructurePolicy(this IApplicationBuilder app)
    {
        SharedServiceContainer.AddSharedMiddlewares(app);
    }
}
