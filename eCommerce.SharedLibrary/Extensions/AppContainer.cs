using eCommerce.SharedLibrary.Extensions.Authentication;
using eCommerce.SharedLibrary.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace eCommerce.SharedLibrary.Extensions;
public static class AppContainer
{
    public static IServiceCollection AddSharedServices<IContext>
        (this IServiceCollection services, IConfiguration config) where IContext : DbContext
    {
        services.AddDbContext<IContext>(options =>
        {
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"),
                sqlServerOpt => sqlServerOpt.EnableRetryOnFailure());
        });

        // configure serilog logging
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.File(path: "databaseLogs.txt",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        AuthenticationScheme.AddAuthenticationScheme(services, config);

        return services;

    }

    public static IApplicationBuilder UseSharedMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalException>();
        app.UseMiddleware<RequireApiGateway>();
        return app;
    }
}
