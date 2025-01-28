namespace eCommerce.ProductApi.Services.Interfaces;

public interface ICacheService
{
    Task<T?> GetCachedDataAsync<T>(string key);
    Task SetCachedDataAsync<T>(string key, T data, TimeSpan expiration);
    Task RemoveCacheDataAsync(string key);
}
