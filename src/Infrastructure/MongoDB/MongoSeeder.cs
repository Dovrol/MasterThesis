using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Infrastructure.MongoDB
{
    public class MongoSeeder
    {
        private const string customersPath = "MockData/customers.json";
        private readonly string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private readonly IMongoCollection<Customer> _customers;
        public MongoSeeder(IMongoContext mongoContext)
        {
            _customers = mongoContext.GetCollection<Customer>();
        }

        public async Task Seed()
        {
            if (!_customers.Find(x => true).Any())
            {
                await _customers.InsertManyAsync(GetCustomers());
            }
        }

        public List<Customer> GetCustomers()
        {
            var file = File.ReadAllText(Path.Combine(assemblyPath, customersPath));

            return JsonConvert.DeserializeObject<List<Customer>>(file);
        }
    }
}