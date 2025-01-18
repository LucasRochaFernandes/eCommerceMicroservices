using Microsoft.AspNetCore.Http;

namespace eCommerce.SharedLibrary.Middlewares;
public class RequireApiGateway
{
    private readonly RequestDelegate _next;
    public RequireApiGateway(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var signedHeader = context.Request.Headers["Api-Gateway"];
        if (signedHeader.FirstOrDefault() is null)
        {
            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            await context.Response.WriteAsync("Service Unavailable");
        } else
        {
            await _next(context);
        }

    }
}
