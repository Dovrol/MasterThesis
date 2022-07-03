using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.MariaDb
{
    public class MariaDbDbContext : AppDbContext
    {
        public MariaDbDbContext(DbContextOptions<MariaDbDbContext> options) : base(options)
        {}
    }
}