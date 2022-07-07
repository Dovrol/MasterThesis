using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EF.MariaDb
{
    public static class Extensions
    {
        public static IServiceCollection AddMariaDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Databases:MariaDb:ConnectionString"];
            services.AddDbContext<MariaDbDbContext>(ctx => 
                ctx.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 7, 2)), options => {
                    options.EnableRetryOnFailure();
                }));

            services.AddScoped<IMariaDbOrderRepository, MariaDbOrderRepository>();

            return services;
        }
    }
}