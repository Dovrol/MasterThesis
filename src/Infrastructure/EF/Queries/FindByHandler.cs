using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Queries;
using Domain;
using Domain.Entities;
using Infrastructure.EF.Postgres;
using Infrastructure.Performance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Queries
{
    public abstract class FindByHandler<T, U> : IRequestHandler<U, QueryResultDto> 
        where T : AppDbContext
        where U : BaseFindByQuery
    {
        private readonly T _dbContext;
        public FindByHandler(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QueryResultDto> Handle(U request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Orders
                .Include(x => x.Customer)
                .AsQueryable();
            
            if (request.Id is not null)
                query = query.Where(x => x.Number == request.Id);
            
            if (request.CustomerId is not null)
                query = query.Where(x => x.CustomerId == request.CustomerId);

            List<Order> orders = default;
            var performance = await PerformanceService.MesureTimeElapsed(async () => {
                orders = await query.AsNoTracking().ToListAsync();
            });

            return new QueryResultDto {
                Performance = performance,
                RowsReturned =  orders.Count
            };
        }
    }
}