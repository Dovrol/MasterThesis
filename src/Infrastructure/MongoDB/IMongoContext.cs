using MongoDB.Driver;

namespace Infrastructure.MongoDB
{
    public interface IMongoContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}