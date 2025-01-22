using eCommerce.OrderApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;

namespace eCommerce.OrderApi.Services;

public class GetAllProductsService
{
    private readonly IGenericRepository<Product> _productRepository;

    public GetAllProductsService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<Product>> Execute()
    {
        return (await _productRepository.GetAllAsync()).ToList();
    }
}
