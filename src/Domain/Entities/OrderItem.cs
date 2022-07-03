using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public OrderItem(int position, string name, decimal netValue)
        {
            Position = position;
            Name = name;
            NetValue = netValue;
        }

        private OrderItem()
        {
            
        }

        public int Position { get; set; }
        public string Name { get; set; }
        public decimal NetValue { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}