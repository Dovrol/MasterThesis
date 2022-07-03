using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Shared;

namespace Domain.Enums
{
    public class PaymentMethod : Enumeration
    {
        public static readonly PaymentMethod Card = new PaymentMethod(1, "Card");
        public static readonly PaymentMethod Transfer = new PaymentMethod(2, "Transfer");

        public PaymentMethod() { }
        private PaymentMethod(int value, string displayName) : base(value, displayName) { }

        public List<Order> Orders { get; set; }
    }
}