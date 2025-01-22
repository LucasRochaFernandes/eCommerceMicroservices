using eCommerce.OrderApi.Communication.Requests;
using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Application.Services;
public class UpdateProductStockService
{
    private readonly IGenericRepository<Product> _productRepository;

    public UpdateProductStockService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(UpdateProductStockRequest request)
    {
        var productEntity = await _productRepository.FindByIdAsync(request.ProductId);
        if (productEntity is null)
        {
            throw new NotFoundException("Product not found");
        }
        productEntity.Stock = request.newStock;
        await _productRepository.UpdateAsync(productEntity);
    }
}
