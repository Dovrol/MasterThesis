using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Enums;
using Application.Services;
using Domain.Repositories;
using MediatR;

namespace Application.Commands
{
    public class CreateOrders
    {
        public class Command : IRequest<PerformanceDto>
        {
            public int N { get; set; }
            public SupportedDb Db { get; set; }
        }

        public class Handler : IRequestHandler<Command, PerformanceDto>
        {
            private readonly IOrderService _orderService;
            private readonly IPostgresOrderRepository _postgresOrderRepository;
            private readonly IMySqlOrderRepository _mySqlOrderRepository;
        private readonly IMariaDbOrderRepository _mariaDbOrderRepository;

            public Handler(IMySqlOrderRepository mySqlOrderRepository,
                           IPostgresOrderRepository postgresOrderRepository,
                           IMariaDbOrderRepository mariaDbOrderRepository,
                           IOrderService orderService)
            {
                _mariaDbOrderRepository = mariaDbOrderRepository;
                _mySqlOrderRepository = mySqlOrderRepository;
                _postgresOrderRepository = postgresOrderRepository;
                _orderService = orderService;
            }

            public async Task<PerformanceDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var orders = _orderService.CreateOrders(request.N);

                Stopwatch stopwatch = new Stopwatch();

                IOrderRepository repository = request.Db switch 
                {
                    SupportedDb.MySQL => _mySqlOrderRepository,
                    SupportedDb.Postgres => _postgresOrderRepository,
                    SupportedDb.MariaDb => _mariaDbOrderRepository,
                    _ => throw new Exception("Db not supported")
                };

                stopwatch.Start();
                await repository.AddAsync(orders);  
                stopwatch.Stop();
        
                TimeSpan ts = stopwatch.Elapsed;
                                
                return new PerformanceDto {
                    Hours = ts.Hours,
                    Minutes = ts.Minutes,
                    Seconds = ts.Seconds,
                    Miliseconds = ts.Milliseconds
                };
            }
        }
    }
}