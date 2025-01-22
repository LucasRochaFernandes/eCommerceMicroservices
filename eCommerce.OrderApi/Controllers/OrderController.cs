using eCommerce.OrderApi.Application.Services;
using eCommerce.OrderApi.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.OrderApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderRequest request,
        [FromServices] CreateOrderService createOrderService)
    {
        var orderId = await createOrderService.Execute(request);
        return Created(string.Empty, new { OrderId = orderId });
    }

    [HttpGet]
    [Route("{orderId}")]
    public async Task<IActionResult> GetOrder(
        [FromRoute] Guid orderId,
        [FromServices] GetOrderDetailsByIdService getOrderDetailsByIdService)
    {
        var order = await getOrderDetailsByIdService.Execute(orderId);
        return Ok(order);
    }
}
