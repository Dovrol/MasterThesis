using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.Repositories
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private IMongoCollection<Order> _orders;
        public MongoDbRepository(IMongoContext mongoContext)
        {
            _orders = mongoContext.GetCollection<Order>();
        }
        public async Task AddAsync(IEnumerable<Order> orders)
        {
            await _orders.InsertManyAsync(orders);
        }
    }
}