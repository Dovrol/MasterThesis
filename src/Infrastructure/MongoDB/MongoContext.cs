using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.MongoDB.Connection;
using MongoDB.Driver;

namespace Infrastructure.MongoDB
{
    public class MongoContext<TConn> : IMongoContext
        where TConn : IMongoConnection
    {
        private IMongoClient _client { get; set; }
        private IMongoDatabase _database { get; set; }

        public MongoContext(TConn connection)
        {
            var url = new MongoUrl(connection.GetConnectionString());
            _client = new MongoClient(url.Url);
            _database = _client.GetDatabase(url.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}