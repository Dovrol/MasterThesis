using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Performance;
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
        public async Task<PerformanceResult> AddAsync(IEnumerable<Order> orders)
        {
            return await PerformanceService.MesureTimeElapsed(async () => {
                await _orders.InsertManyAsync(orders);
            });
        }
    }
}