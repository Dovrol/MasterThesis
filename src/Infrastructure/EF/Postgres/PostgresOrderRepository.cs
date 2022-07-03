using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Repositories;

namespace Infrastructure.EF.Postgres
{
    public class PostgresOrderRepository : OrderRepository<PostgresDbContext>, IPostgresOrderRepository
    {
        public PostgresOrderRepository(PostgresDbContext dbContext) : base(dbContext)
        {}
    }
}