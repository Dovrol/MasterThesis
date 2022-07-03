using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var orders = new List<Order>();

            for (var i = 0; i < numberOfOrders; i++)
            {
                var paymentMethod = Enumeration.GetAll<PaymentMethod>();
                var deliveryMethod = Enumeration.GetAll<DeliveryMethod>();

                var order = new Order(GetRandomElement(paymentMethod),
                                        GetRandomElement(deliveryMethod),
                                        POLISH_TAX,
                                        RandomNumber(1, 1000));


                var numberOfItems = RandomNumber(ITEMS_PER_ORDER_MIN, ITEMS_PER_ORDER_MAX);

                for (var j = 1; j <= numberOfItems; j++)
                {
                    var price = RandomNumber(1, 500);
                    order.AddItem(new OrderItem(j, "aa", price));
                }

                orders.Add(order);
            }

            return orders;
        }
        private int GetRandomElement<T>(IEnumerable<T> options) where T : Enumeration, new()
        {
            return options.OrderBy(x => Guid.NewGuid()).FirstOrDefault().Value;
        }

        public int RandomNumber(int min, int max)
            => new Random().Next(min, max);
    }
}