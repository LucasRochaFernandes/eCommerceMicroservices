using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.ProductApi.Infrastructure.Repositories;
using eCommerce.SharedLibrary.Extensions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Infrastructure.Extensions;
public static class ProductApiInfrastructureContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        SharedServiceContainer.AddSharedServices(services, config, "ProductApi-Infra-Logs");
        services.AddScoped<IGenericRepository<Product>, ProductRepository>();
        services.AddScoped<CreateProductService>();
        services.AddScoped<GetAllProductsService>();
        services.AddScoped<RemoveProductService>();
    }

    public static void AddInfrastructurePolicy(this IApplicationBuilder app)
    {
        SharedServiceContainer.AddSharedMiddlewares(app);
    }
}
