using eCommerce.ProductApi.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace eCommerce.ProductApi.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public RedisCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }
    public async Task<T?> GetCachedDataAsync<T>(string key)
    {
        var cachedData = await _cache.GetStringAsync(key);
        return cachedData != null ? JsonSerializer.Deserialize<T>(cachedData) : default;
    }

    public async Task RemoveCacheDataAsync(string key)
    {
        await _cache.RemoveAsync(key);
    }

    public async Task SetCachedDataAsync<T>(string key, T data, TimeSpan expiration)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        };

        var serializedData = JsonSerializer.Serialize(data);
        await _cache.SetStringAsync(key, serializedData, options);
    }
}
