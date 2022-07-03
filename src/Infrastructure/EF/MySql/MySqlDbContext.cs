using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.MySql
{
    public class MySqlDbContext : AppDbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {}
    }
}