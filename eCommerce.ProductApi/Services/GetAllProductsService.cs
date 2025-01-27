using eCommerce.ProductApi.Domain.Entities;
using eCommerce.SharedLibrary.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace eCommerce.ProductApi.Application.Services;
public class GetAllProductsService
{
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMemoryCache _cache;

    public GetAllProductsService(IGenericRepository<Product> productRepository, IMemoryCache cache)
    {
        _productRepository = productRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<Product>> Execute()
    {
        const string cacheKey = "Products";

        if (!_cache.TryGetValue(cacheKey, out IEnumerable<Product> productsCache))
        {
            productsCache = await _productRepository.GetAllAsync();
            _cache.Set(cacheKey, productsCache, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }
        return productsCache ?? [];
    }
}
