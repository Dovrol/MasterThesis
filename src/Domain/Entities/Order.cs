using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public Order(int paymentMethodId, int deliveryMethodId, decimal tax, int customerId)
        {
            PaymentMethodId = paymentMethodId;
            DeliveryMethodId = deliveryMethodId;
            Tax = tax;
            CustomerId = customerId;
        }

        public int Number { get; private set; }
        public int PaymentMethodId { get; private set; }
        public int DeliveryMethodId { get; private set; }
        public bool FreeDelivery
        {
            get => GrossValue > 250;
            private set {}
        } 
        public decimal GrossValue
        {
            get =>  NetValue + TaxValue;
            private set {}
        }
        public decimal NetValue
        {
            get => Items.Sum(x => x.NetValue);
            private set {}
        } 
        public decimal TaxValue
        {
            get => NetValue * Tax;
            private set {}
        }
        public decimal Tax { get; private set; }
        public DateTime CreationDate { get; private set; } = DateTime.UtcNow;
        public DateTime FulfillmentDate { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }           
        public DeliveryMethod DeliveryMethod { get; private set; }
        private List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();


        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}