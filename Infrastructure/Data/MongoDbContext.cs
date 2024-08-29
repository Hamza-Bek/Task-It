using MongoDB.Driver;

namespace Infrastructure.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    /// <summary>
    /// Retrieves the specified collection from the database
    /// </summary>
    /// <typeparam name="T">The data model the collection represents</typeparam>
    /// <param name="collectionName">The name of the collection</param>
    /// <returns></returns>
    public IMongoCollection<T> GetCollection<T>(string collectionName) where T : class
    {
        return _database.GetCollection<T>(collectionName);
    }
}
