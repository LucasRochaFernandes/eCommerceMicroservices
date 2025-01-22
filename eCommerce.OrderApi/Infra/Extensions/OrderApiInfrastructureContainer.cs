using eCommerce.OrderApi.Application.Services;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Repositories;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.OrderApi.Infrastructure.Extensions;
public static class OrderApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Order>, OrderRepository>();
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateOrderService>();
        services.AddScoped<GetOrderDetailsByIdService>();
        services.AddScoped<UpdateProductStockService>();
    }
}
