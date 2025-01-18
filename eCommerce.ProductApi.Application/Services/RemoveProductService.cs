using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Exceptions;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Application.Services;
public class RemoveProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    public RemoveProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task Execute(Guid id)
    {
        var product = await _productRepository.FindByIdAsync(id);
        if (product is null)
        {
            throw new NotFoundException("Product not found");
        }
        await _productRepository.DeleteAsync(product);
    }
}
