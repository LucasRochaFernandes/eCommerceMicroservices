using eCommerce.OrderApi.Application.Services;
using eCommerce.OrderApi.Communication.Requests;
using eCommerce.SharedLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eCommerce.OrderApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderRequest request,
        [FromServices] CreateOrderService createOrderService)
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        if (userEmail is null)
        {
            throw new UnauthorizedException("Invalid Credentials");
        }
        var orderId = await createOrderService.Execute(request, userEmail);
        return Created(string.Empty, new { OrderId = orderId });
    }

    [HttpGet]
    public async Task<IActionResult> GetOrder(
        [FromServices] GetOrderDetailsByIdService getOrderDetailsByIdService)
    {
        var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        if (userEmail is null)
        {
            throw new UnauthorizedException("Invalid Credentials");
        }
        var orderDetails = await getOrderDetailsByIdService.Execute(userEmail);
        return Ok(orderDetails);
    }
}
