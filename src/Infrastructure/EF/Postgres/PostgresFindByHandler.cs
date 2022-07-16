using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.EF.Queries;

namespace Infrastructure.EF.Postgres
{
    public class PostgresFindByHandler : FindByHandler<PostgresDbContext, PostgresFindBy>
    {
        public PostgresFindByHandler(PostgresDbContext dbContext) : base(dbContext)
        {
        }
    }
}