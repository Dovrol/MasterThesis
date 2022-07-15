using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Number { get; set; }
        public int PaymentMethodId { get; set; }
        public int DeliveryMethodId { get; set; }
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
            get => Math.Round(NetValue * Tax, 2);
            private set {}
        }
        public decimal Tax { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? FulfillmentDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public PaymentMethod PaymentMethod { get; set; }           
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItem> Items = new List<OrderItem>();
    }
}