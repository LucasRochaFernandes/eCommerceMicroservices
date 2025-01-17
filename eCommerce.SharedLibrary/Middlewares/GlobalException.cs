using eCommerce.SharedLibrary.Logging.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace eCommerce.SharedLibrary.Middlewares;
public class GlobalException
{
    private readonly RequestDelegate _next;
    public GlobalException(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (TimeoutException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status408RequestTimeout;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                Title = "Timeout Error",
                StatusCode = StatusCodes.Status408RequestTimeout,
                Message = "Out of time... try again",
                Details = ex.Message
            }), CancellationToken.None);
            LogException.LogExceptions(ex);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                Title = "Internal Server Error",
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "An unexpected error occurred while processing your request",
                Details = ex.Message
            }), CancellationToken.None);
            LogException.LogExceptions(ex);
        }
    }
}
