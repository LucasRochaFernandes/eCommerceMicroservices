using eCommerce.ApiGateway.Middlewares;
using eCommerce.SharedLibrary.Extensions.Authentication;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var isSvcKubernetes = Environment.GetEnvironmentVariable("SVC_Kubernetes");
if (isSvcKubernetes == null)
{
    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
} else
{
    builder.Configuration.AddJsonFile("ocelot.SVC.json", optional: false, reloadOnChange: true);
}

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddMemoryCache();

builder.Services.AddAuthenticationScheme(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseMiddleware<AttachSignatureToRequest>();

await app.UseOcelot();

app.Run();
