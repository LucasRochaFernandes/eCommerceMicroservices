using eCommerce.AuthenticationApi.Domain.Entities;
using eCommerce.AuthenticationApi.Infra.Database;
using eCommerce.SharedLibrary.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace eCommerce.AuthenticationApi.Infra.Repositories;

public class UserRepository : IGenericRepository<User>
{
    private readonly IMongoCollection<User> _userCollection;

    public UserRepository(MongoDbService mongoDbService)
    {
        _userCollection = mongoDbService.GetDatabase().GetCollection<User>("users");
        CreateIndexes();
    }

    private void CreateIndexes()
    {
        var indexKeys = Builders<User>.IndexKeys.Ascending(u => u.Email);
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexModel = new CreateIndexModel<User>(indexKeys, indexOptions);

        _userCollection.Indexes.CreateOne(indexModel);
    }
    public async Task<Guid> CreateAsync(User entity)
    {
        await _userCollection.InsertOneAsync(entity);
        return entity.Id;
    }

    public async Task DeleteAsync(User entity)
    {
        var filter = Builders<User>.Filter.Eq(p => p.Id, entity.Id);
        await _userCollection.DeleteOneAsync(filter);
    }

    public async Task<User?> FindByIdAsync(Guid id)
    {
        var filter = Builders<User>.Filter.Eq(p => p.Id, id);
        var User = await _userCollection.Find(filter).FirstOrDefaultAsync();
        return User;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var products = await _userCollection.Find(p => true).ToListAsync();
        return products;
    }

    public async Task<User?> GetByAsync(Expression<Func<User, bool>> predicate)
    {
        var User = await _userCollection.Find(predicate).FirstOrDefaultAsync();
        return User;
    }

    public async Task UpdateAsync(User entity)
    {
        var filter = Builders<User>.Filter.Eq(p => p.Id, entity.Id);
        await _userCollection.ReplaceOneAsync(filter, entity);
    }
}
