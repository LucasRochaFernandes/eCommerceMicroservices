using eCommerce.OrderApi.Application.Services;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.OrderApi.Infrastructure.Repositories;
using eCommerce.OrderApi.Services;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Infrastructure.Extensions;
public static class OrderApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<Order>, OrderRepository>();
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateOrderService>();
        services.AddScoped<GetAllProductsService>();
        services.AddScoped<GetOrderDetailsByIdService>();
        services.AddScoped<UpdateProductStockService>();
    }
}
