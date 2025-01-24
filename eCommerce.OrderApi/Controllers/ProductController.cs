using eCommerce.OrderApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.OrderApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CreateProduct(
        [FromServices] GetAllProductsService getAllProductsService)
    {
        var result = await getAllProductsService.Execute();
        return Ok(result);
    }
}
