using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Shared;

namespace Domain.Enums
{
    public class DeliveryMethod : Enumeration
    {
        public static readonly DeliveryMethod Inpost = new DeliveryMethod(1, "Inpost");
        public static readonly DeliveryMethod UPS = new DeliveryMethod(2, "UPS");
        public static readonly DeliveryMethod DPD = new DeliveryMethod(3, "DPD");
        public static readonly DeliveryMethod DHL = new DeliveryMethod(4, "DHL");

        public DeliveryMethod() { }
        private DeliveryMethod(int value, string displayName) : base(value, displayName) { }

        public List<Order> Orders { get; set; }
    }
}