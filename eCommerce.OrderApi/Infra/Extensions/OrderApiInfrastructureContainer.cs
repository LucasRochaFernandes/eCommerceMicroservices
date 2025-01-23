using eCommerce.OrderApi.Application.Services;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Database;
using eCommerce.OrderApi.Infrastructure.Repositories;
using eCommerce.OrderApi.Services;
using eCommerce.SharedLibrary.Extensions;
using eCommerce.SharedLibrary.Interfaces;
using MassTransit;

namespace eCommerce.OrderApi.Infrastructure.Extensions;
public static class OrderApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        SharedServiceContainer.AddSharedServices(services, config, "ProductApi-Infra-Logs");
        services.AddDbContext<OrderApiDbContext>();
        services.AddMassTransit(busConfig =>
        {
            busConfig.AddConsumer<SubProductCreatedService>();
            busConfig.AddConsumer<SubProductStockUpdated>();
            busConfig.AddConsumer<SubUserCreatedService>();
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
        services.AddScoped<IGenericRepository<Order>, OrderRepository>();
        services.AddScoped<IGenericRepository<User>, UserRepository>();
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateOrderService>();
        services.AddScoped<GetAllProductsService>();
        services.AddScoped<GetOrderDetailsByIdService>();
        services.AddScoped<UpdateProductStockService>();
    }
}
