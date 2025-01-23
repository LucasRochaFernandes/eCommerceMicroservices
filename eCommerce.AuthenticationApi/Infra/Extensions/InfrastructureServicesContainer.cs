using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.AuthenticationApi.Infra.Database;
using eCommerce.AuthenticationApi.Infra.Repositories;
using eCommerce.AuthenticationApi.Services;
using eCommerce.SharedLibrary.Interfaces;
using MassTransit;

namespace eCommerce.AuthenticationApi.Infra.Extensions;

public static class InfrastructureServicesContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {

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
        services.AddScoped<CreateUserService>();
        services.AddScoped<PubUserCreatedService>();
        services.AddScoped<AuthenticateService>();
        services.AddScoped<GetAllUsersService>();
        services.AddScoped<IGenericRepository<User>, UserRepository>();
        services.AddSingleton<MongoDbService>();
    }
}
