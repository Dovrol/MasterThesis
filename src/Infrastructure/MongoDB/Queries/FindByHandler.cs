using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Queries;
using Domain.Entities;
using Infrastructure.Performance;
using MediatR;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.Queries
{
    public class MongoDbFindByHandler : IRequestHandler<MongoDbFindBy, QueryResultDto>
    {
        private IMongoCollection<Order> _orders;
        public MongoDbFindByHandler(IMongoContext mongoContext)
        {
            _orders = mongoContext.GetCollection<Order>();
        }

        public async Task<QueryResultDto> Handle(MongoDbFindBy request, CancellationToken cancellationToken)
        {
            var builder = Builders<Order>.Filter;
            var filter = builder.Empty;

            if (request.Id is not null)
            {
                filter &= builder.Where(x => x.Number == request.Id);
            }
            if (request.CustomerId is not null)
            {
                filter &= builder.Where(x => x.CustomerId == request.CustomerId);
            }

            List<Order> orders = default;
            var performance = await PerformanceService.MesureTimeElapsed(async () => {
                orders = await _orders.Find(filter).ToListAsync();
            });

            return new QueryResultDto {
                Performance = performance,
                RowsReturned =  orders.Count
            };
        }
    }
}