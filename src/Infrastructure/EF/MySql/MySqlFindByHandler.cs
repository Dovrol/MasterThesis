using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.EF.Queries;

namespace Infrastructure.EF.MySql
{
    public class MySqlFindByHandler : FindByHandler<MySqlDbContext, MySqlFindBy>
    {
        public MySqlFindByHandler(MySqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}