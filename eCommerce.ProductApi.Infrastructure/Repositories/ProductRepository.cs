using eCommerce.ProductApi.Domain.Entities;
using eCommerce.ProductApi.Infrastructure.Database;
using eCommerce.SharedLibrary.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace eCommerce.ProductApi.Infrastructure.Repositories;

public class ProductRepository : IGenericRepository<Product>
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductRepository(MongoDbService mongoDbService)
    {
        _productCollection = mongoDbService.GetDatabase().GetCollection<Product>("products");
    }

    public async Task<Guid> CreateAsync(Product entity)
    {
        await _productCollection.InsertOneAsync(entity);
        return entity.Id;
    }

    public async Task DeleteAsync(Product entity)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, entity.Id);
        await _productCollection.DeleteOneAsync(filter);
    }

    public async Task<Product?> FindByIdAsync(Guid id)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
        var product = await _productCollection.Find(filter).FirstOrDefaultAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _productCollection.Find(p => true).ToListAsync();
        return products;
    }

    public async Task<Product?> GetByAsync(Expression<Func<Product, bool>> predicate)
    {
        var product = await _productCollection.Find(predicate).FirstOrDefaultAsync();
        return product;
    }

    public async Task UpdateAsync(Product entity)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, entity.Id);
        await _productCollection.ReplaceOneAsync(filter, entity);
    }
}
