using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Infrastructure.EF.Queries;

namespace Infrastructure.EF.MariaDb
{
    public class MariaDbFindByHandler : FindByHandler<MariaDbDbContext, MariaDbFindBy>
    {
        public MariaDbFindByHandler(MariaDbDbContext dbContext) : base(dbContext)
        {
        }
    }
}