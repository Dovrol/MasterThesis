using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Enums;
using Application.Services;
using Domain;
using Domain.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CreateOrders
    {
        public class Command : IRequest<PerformanceResult>
        {
            public int N { get; set; }
            public SupportedDb Db { get; set; }
            public int Seed { get; set; }
        }

        public class Handler : IRequestHandler<Command, PerformanceResult>
        {
            private readonly IOrderService _orderService;
            private readonly IPostgresOrderRepository _postgresOrderRepository;
            private readonly IMySqlOrderRepository _mySqlOrderRepository;
            private readonly IMariaDbOrderRepository _mariaDbOrderRepository;
            private readonly IMongoDbRepository _mongoDbOrderRepository;

            public Handler(IMySqlOrderRepository mySqlOrderRepository,
                           IPostgresOrderRepository postgresOrderRepository,
                           IMariaDbOrderRepository mariaDbOrderRepository,
                           IMongoDbRepository mongoDbRepository,
                           IOrderService orderService)
            {
                _mariaDbOrderRepository = mariaDbOrderRepository;
                _mySqlOrderRepository = mySqlOrderRepository;
                _postgresOrderRepository = postgresOrderRepository;
                _mongoDbOrderRepository = mongoDbRepository;
                _orderService = orderService;
            }

            public async Task<PerformanceResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var orders = _orderService.CreateOrders(request.N, request.Seed);


                IOrderRepository repository = request.Db switch 
                {
                    SupportedDb.MySQL => _mySqlOrderRepository,
                    SupportedDb.Postgres => _postgresOrderRepository,
                    SupportedDb.MariaDb => _mariaDbOrderRepository,
                    SupportedDb.MongoDb => _mongoDbOrderRepository,
                    _ => throw new Exception("Db not supported")
                };

                return await repository.AddAsync(orders);  
            }
        }
    }
}