using MinimalApiDemo.Features.Pet;
using MongoDB.Driver;

namespace MinimalApiDemo.Database;

public class DbContext
{
    private readonly IMongoDatabase _database;

    public DbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("Database:Url").Value;
        var databaseName = configuration.GetSection("Database:Name").Value;

        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    
    public IMongoCollection<Pet> Pets => _database.GetCollection<Pet>("pets");
}