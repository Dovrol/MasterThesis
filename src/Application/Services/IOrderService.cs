using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities;
using Domain.Enums;
using Domain.Shared;

namespace Application.Services
{
    public interface IOrderService
    {
        List<Order> CreateOrders(int numberOfOrders, int seed);
    }

    public class OrderService : IOrderService
    {
        private const decimal POLISH_TAX = 0.23M;
        private const int ITEMS_PER_ORDER_MIN = 1;
        private const int ITEMS_PER_ORDER_MAX = 10;

        public List<Order> CreateOrders(int numberOfOrders, int seed)
        {
            Randomizer.Seed = new Random(seed);

            var position = 1;
            var testOrderItem = new Faker<OrderItem>()
                .RuleFor(o => o.Position, f => position++)
                .RuleFor(o => o.Name, f => f.Commerce.ProductName())
                .RuleFor(o => o.NetValue, f => f.Finance.Amount(1, 500, 2));

            var testOrders = new Faker<Order>()
                .RuleFor(o => o.Number, f => Guid.NewGuid())
                .RuleFor(o => o.PaymentMethodId, f => f.PickRandom(Enumeration.GetAll<PaymentMethod>()).Value)
                .RuleFor(o => o.DeliveryMethodId, f => f.PickRandom(Enumeration.GetAll<DeliveryMethod>()).Value)
                .RuleFor(o => o.Tax, f => POLISH_TAX)
                .RuleFor(o => o.CustomerId, f => f.Random.Int(1, 1000))
                .RuleFor(o => o.CreationDate, f => f.Date.Between(DateTime.Now.AddMonths(-1), DateTime.Now).ToUniversalTime())
                .RuleFor(o => o.Items, f => testOrderItem.GenerateBetween(ITEMS_PER_ORDER_MIN, ITEMS_PER_ORDER_MAX))
                .FinishWith((d, o) => {
                    position = 1;
                });

            return testOrders.Generate(numberOfOrders);
        }
    }
}