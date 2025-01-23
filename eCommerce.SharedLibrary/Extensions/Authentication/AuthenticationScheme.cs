using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eCommerce.SharedLibrary.Extensions.Authentication;
public static class AuthenticationScheme
{
    public static void AddAuthenticationScheme(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 var jwtSettings = configuration.GetSection("JwtSettings");
                 var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                 options.RequireHttpsMetadata = environment == "Production";
                 options.SaveToken = true;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtSettings["Issuer"],
                     ValidAudience = jwtSettings["Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
                 };
             });
        services.AddAuthorization();
    }
}
