using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.EF.Postgres;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.EF
{
    public class EFSeeder<T> where T : AppDbContext
    {
        private const string customersPath = "MockData/customers.json";
        private readonly string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private readonly T _dbContext;
        public EFSeeder(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            await _dbContext.Database.MigrateAsync();

            if (!_dbContext.Customers.Any())
            {
                await _dbContext.Customers.AddRangeAsync(GetCustomers());
            }

            if (!_dbContext.PaymentMethods.Any())
            {
                await _dbContext.PaymentMethods.AddRangeAsync(GetPaymentMethods());
            }

            if (!_dbContext.DeliveryMethods.Any())
            {
                await _dbContext.DeliveryMethods.AddRangeAsync(GetDeliveryMethods());
            }

            await _dbContext.SaveChangesAsync();
        }

        public List<Customer> GetCustomers()
        {
            var file = File.ReadAllText(Path.Combine(assemblyPath, customersPath));

            return JsonConvert.DeserializeObject<List<Customer>>(file);
        }


        public List<PaymentMethod> GetPaymentMethods()
        {
            return new List<PaymentMethod> {
                PaymentMethod.Card,
                PaymentMethod.Transfer
            };
        }

        public List<DeliveryMethod> GetDeliveryMethods()
        {
            return new List<DeliveryMethod> {
                DeliveryMethod.DHL,
                DeliveryMethod.DPD,
                DeliveryMethod.UPS,
                DeliveryMethod.Inpost
            };
        }
    }
}