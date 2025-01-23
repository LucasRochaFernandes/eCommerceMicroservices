using MongoDB.Driver;

namespace eCommerce.AuthenticationApi.Infra.Database;

public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
    {
        _configuration = configuration;
        var mongoUrl = MongoUrl.Create(_configuration.GetConnectionString("MongoDb"));
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}

