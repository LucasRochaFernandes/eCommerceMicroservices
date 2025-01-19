using eCommerce.SharedLibrary.Extensions.Authentication;
using eCommerce.SharedLibrary.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace eCommerce.SharedLibrary.Extensions;
public static class SharedServiceContainer
{
    public static void AddSharedServices<IContext>
        (this IServiceCollection services, IConfiguration config, string logsFileName) where IContext : DbContext
    {
        services.AddDbContext<IContext>();



        // configure serilog logging
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Debug()
            .WriteTo.Console()
            .WriteTo.File(path: logsFileName,
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        AuthenticationScheme.AddAuthenticationScheme(services, config);
    }

    public static void AddSharedMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalException>();
        //app.UseMiddleware<RequireApiGateway>();
    }
}
