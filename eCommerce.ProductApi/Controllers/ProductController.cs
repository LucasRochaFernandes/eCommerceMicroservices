using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] ProductRequest body,
        [FromServices] CreateProductService createProductService)
    {
        var result = await createProductService.Execute(body);
        return Created(string.Empty, new { Id = result });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] GetAllProductsService getAllProductsService)
    {
        return Ok(await getAllProductsService.Execute());
    }
    [HttpDelete]
    [Route("{productId}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid productId,
        [FromServices] RemoveProductService removeProductService)
    {
        await removeProductService.Execute(productId);
        return Ok();
    }
}
