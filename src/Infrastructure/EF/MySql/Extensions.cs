using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EF.MySql
{
    public static class Extensions
    {
        public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Databases:MySql:ConnectionString"];
            services.AddDbContext<MySqlDbContext>(ctx => ctx.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29))));

            services.AddScoped<IMySqlOrderRepository, MySqlOrderRepository>();

            return services;
        }
    }
}