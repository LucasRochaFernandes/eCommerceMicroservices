﻿using eCommerce.ProductApi.Application.Services;
using eCommerce.ProductApi.Communication.Requests;
using eCommerce.ProductApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace eCommerce.ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(
        [FromBody] ProductRequest body,
        [FromServices] CreateProductService createProductService,
        [FromServices] PubProductCreatedService pubProductCreatedService)
    {
        var result = await createProductService.Execute(body);
        await pubProductCreatedService.Execute(result);
        return Created(string.Empty, new { Id = result });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllProductsService getAllProductsService,
        IMemoryCache cache)
    {

        return Ok(await getAllProductsService.Execute());
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
