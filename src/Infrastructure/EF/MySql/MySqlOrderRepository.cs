using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Repositories;

namespace Infrastructure.EF.MySql
{
    public class MySqlOrderRepository : OrderRepository<MySqlDbContext>, IMySqlOrderRepository
    {
        public MySqlOrderRepository(MySqlDbContext dbContext) : base(dbContext)
        {}
    }
}