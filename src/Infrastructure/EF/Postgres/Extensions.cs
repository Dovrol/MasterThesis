using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EF.Postgres
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Databases:Postgres:ConnectionString"];
            services.AddDbContext<PostgresDbContext>(ctx => ctx.UseNpgsql(connectionString, options => {
                    options.EnableRetryOnFailure();
                }));

            services.AddScoped<IPostgresOrderRepository, PostgresOrderRepository>();

            return services;
        }
    }
}