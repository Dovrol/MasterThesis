using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Domain;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.EF.Postgres;
using Infrastructure.Performance;

namespace Infrastructure.EF.Repositories
{
    public abstract class OrderRepository<T> where T : AppDbContext
    {
        private readonly T _dbContext;

        public OrderRepository(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PerformanceResult> AddAsync(IEnumerable<Order> orders)
        {                                
            var performance =  await PerformanceService.MesureTimeElapsed(async () => {
                await _dbContext.BulkInsertAsync(orders, options => options.AutoMapOutputDirection = false);
            });

            return performance;
        }
    }
}