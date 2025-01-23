using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.AuthenticationApi.Infra.Repositories;
using eCommerce.AuthenticationApi.Services;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.AuthenticationApi.Infra.Extensions;

public static class InfrastructureServicesContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<CreateUserService>();
        services.AddScoped<IGenericRepository<User>, UserRepository>();
    }
}
