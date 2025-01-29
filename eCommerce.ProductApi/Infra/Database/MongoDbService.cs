using MongoDB.Driver;

namespace eCommerce.ProductApi.Infrastructure.Database;
public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase _database;

    public MongoDbService(IConfiguration configuration)
    {

        _configuration = configuration;
        var mongoDbHost = Environment.GetEnvironmentVariable("MongoDb__Host");
        if (string.IsNullOrEmpty(mongoDbHost))
        {
            mongoDbHost = _configuration["MongoDb:Host"];
        }
        var mongoUrl = MongoUrl.Create(mongoDbHost);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}
