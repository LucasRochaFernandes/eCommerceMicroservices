using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Communication.Requests;
using eCommerce.ProductApi.Domain.Entities;
using eCommerce.ProductApi.Services;
using eCommerce.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly string cacheKey = "products";

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(
        [FromBody] ProductRequest body,
        [FromServices] CreateProductService createProductService,
        [FromServices] PubProductCreatedService pubProductCreatedService,
        [FromServices] ICacheService cacheService)
    {
        var result = await createProductService.Execute(body);
        await pubProductCreatedService.Execute(result);
        await cacheService.RemoveCacheDataAsync(cacheKey);
        return Created(string.Empty, new { Id = result });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllProductsService getAllProductsService,
        [FromServices] ICacheService redisCacheService)
    {
        var productsCache = await redisCacheService.GetCachedDataAsync<IEnumerable<Product>>(cacheKey);
        if (productsCache == null)
        {
            var products = await getAllProductsService.Execute();
            await redisCacheService.SetCachedDataAsync(cacheKey, products, TimeSpan.FromMinutes(5));
            return Ok(products);
        }
        else
        {
            return Ok(productsCache);
        }
    }
    [HttpDelete]
    [Route("{productId}")]
    [Authorize]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid productId,
        [FromServices] RemoveProductService removeProductService)
    {
        await removeProductService.Execute(productId);
        return Ok();
    }
    [HttpPatch("{productId}/stock")]
    [Authorize]
    public async Task<IActionResult> UpdateStock(
        [FromRoute] Guid productId,
        [FromBody] NewProductStockRequest body,
        [FromServices] UpdateProductStockService updateProductStockService,
        [FromServices] PubProductStockUpdated pubProductStockUpdated)
    {
        await updateProductStockService.Execute(productId, body.NewStock);
        await pubProductStockUpdated.Execute(productId, body.NewStock);
        return Ok();
    }

}
