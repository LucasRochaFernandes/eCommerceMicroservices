using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.ProductApi.Application.Services;
public class GetAllProductsService
{
    private readonly IGenericRepository<Product> _productRepository;

    public GetAllProductsService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Execute()
    {
        return await _productRepository.GetAllAsync() ?? [];
    }
}
