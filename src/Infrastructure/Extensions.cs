using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EF;
using Infrastructure.EF.MariaDb;
using Infrastructure.EF.MySql;
using Infrastructure.EF.Postgres;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                           IConfiguration configuration)
        {
            services.AddPostgres(configuration);
            services.AddMySql(configuration);
            services.AddMariaDb(configuration);

            services.AddScoped(typeof(Seeder<>));
            services.AddMediatR(typeof(Infrastructure.Extensions).Assembly,
                                typeof(Application.Extensions).Assembly);
            
            return services;
        }
    }
}