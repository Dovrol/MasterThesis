using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.EF.Postgres;

namespace Infrastructure.EF.Repositories
{
    public abstract class OrderRepository<T> where T : AppDbContext
    {
        private readonly T _dbContext;

        public OrderRepository(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(IEnumerable<Order> orders)
        {
            await _dbContext.AddRangeAsync(orders);
            await _dbContext.SaveChangesAsync();
        }
    }
}