using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Repositories;

namespace Infrastructure.EF.MariaDb
{
    public class MariaDbOrderRepository : OrderRepository<MariaDbDbContext>, IMariaDbOrderRepository
    {
        public MariaDbOrderRepository(MariaDbDbContext dbContext) : base(dbContext)
        {}
    }
}