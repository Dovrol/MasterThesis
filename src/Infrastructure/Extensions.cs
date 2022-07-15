using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.EF;
using Infrastructure.EF.MariaDb;
using Infrastructure.EF.MySql;
using Infrastructure.EF.Postgres;
using Infrastructure.MongoDB;
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
            //SQL
            services.AddPostgres(configuration);
            services.AddMySql(configuration);
            services.AddMariaDb(configuration);

            //NOSQL
            services.AddMongoDB(configuration);

            services.AddScoped(typeof(EFSeeder<>));
            services.AddMediatR(typeof(Infrastructure.Extensions).Assembly,
                                typeof(Application.Extensions).Assembly);
            
            return services;
        }
    }
}