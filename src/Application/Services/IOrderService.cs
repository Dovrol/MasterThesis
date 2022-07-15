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
        List<Order> CreateOrders(int numberOfOrders);
    }

    public class OrderService : IOrderService
    {
        private const decimal POLISH_TAX = 0.23M;
        private const int ITEMS_PER_ORDER_MIN = 1;
        private const int ITEMS_PER_ORDER_MAX = 10;

        public List<Order> CreateOrders(int numberOfOrders)
        {
            var position = 0;
            var testOrderItem = new Faker<OrderItem>()
                .RuleFor(o => o.Position, f => position++)
                .RuleFor(o => o.Name, f => f.Commerce.ProductName())
                .RuleFor(o => o.NetValue, f => f.Random.Decimal(1, 500));

            var testOrders = new Faker<Order>()
                .RuleFor(o => o.Number, f => Guid.NewGuid())
                .RuleFor(o => o.PaymentMethodId, f => f.PickRandom(Enumeration.GetAll<PaymentMethod>()).Value)
                .RuleFor(o => o.DeliveryMethodId, f => f.PickRandom(Enumeration.GetAll<DeliveryMethod>()).Value)
                .RuleFor(o => o.Tax, f => POLISH_TAX)
                .RuleFor(o => o.CustomerId, f => f.Random.Int(1, 1000))
                .RuleFor(o => o.Items, f => testOrderItem.GenerateBetween(ITEMS_PER_ORDER_MIN, ITEMS_PER_ORDER_MAX));

            return testOrders.Generate(numberOfOrders);
        }
    }
}