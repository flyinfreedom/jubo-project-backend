using MongoDB.Driver;

namespace jubo_project_api.Infrastructure;

public interface IMongoContext : IDisposable
{
    IMongoCollection<T> GetCollection<T>(string name);
}
