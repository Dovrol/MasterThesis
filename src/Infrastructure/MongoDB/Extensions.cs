using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Infrastructure.MongoDB.Configuration;
using Infrastructure.MongoDB.Connection;
using Infrastructure.MongoDB.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.MongoDB
{
    public static class Extensions
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IMongoConnection>(_ =>
            {
                return new MongoConnection(configuration);
            });

            services.AddScoped<IMongoContext, MongoContext<IMongoConnection>>();
            services.AddScoped<IMongoDbRepository, MongoDbRepository>();
            services.AddScoped(typeof(MongoSeeder));


            MongoConfiguration.RegisterDocumentMaps();
            MongoConfiguration.RegisterConventions();
            MongoConfiguration.RegisterGlobalSerializers();

            return services;
        }
    }
}