using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Services;

public class UpdateProductStockService
{
    private readonly IGenericRepository<Product> _productRepository;

    public UpdateProductStockService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(Guid productId, int newStock)
    {
        var product = await _productRepository.FindByIdAsync(productId);
        if (product is null)
        {
            throw new NotFoundException("Product not found");
        }
        product.Stock = newStock;
        await _productRepository.UpdateAsync(product);
    }
}
