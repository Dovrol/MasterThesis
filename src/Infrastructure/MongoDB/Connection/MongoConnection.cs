using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.MongoDB.Connection
{
    public class MongoConnection : IMongoConnection
    {
        private readonly IConfiguration _configuration;
        public MongoConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? GetConnectionString()
            => _configuration["Databases:Mongodb:ConnectionString"];
        
    }
}