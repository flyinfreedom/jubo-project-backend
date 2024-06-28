using MongoDB.Driver;

namespace jubo_project_api.Infrastructure;

public class MongoContext : IMongoContext
{
    private IMongoDatabase _database;
    private MongoClient _mongoClient;
    public IClientSessionHandle? Session = null;

    public MongoContext(string? connectionString, string databaseName)
    {
        if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
        if (databaseName == null) throw new ArgumentNullException(nameof(databaseName));

        _mongoClient = new MongoClient(connectionString);
        _database = _mongoClient.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }

    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);
    }
}
