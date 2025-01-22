using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.ProductApi.Infrastructure.Repositories;
using eCommerce.ProductApi.Services;
using eCommerce.SharedLibrary.Extensions;
using eCommerce.SharedLibrary.Interfaces;
using MassTransit;

namespace eCommerce.ProductApi.Infrastructure.Extensions;
public static class ProductApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        SharedServiceContainer.AddSharedServices(services, config, "ProductApi-Infra-Logs");
        services.AddMassTransit(busConfig =>
        {
            busConfig.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(config["RabbitMQ:Host"], h =>
                {
                    h.Username(config["RabbitMq:Username"]!);
                    h.Password(config["RabbitMq:Password"]!);
                });
                cfg.ConfigureEndpoints(context);
            });

        });
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateProductService>();
        services.AddScoped<PubProductCreatedService>();
        services.AddScoped<GetAllProductsService>();
        services.AddScoped<RemoveProductService>();
    }

    public static void AddInfrastructurePolicy(this IApplicationBuilder app)
    {
        SharedServiceContainer.AddSharedMiddlewares(app);
    }
}
