using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Infrastructure.MongoDB.Configuration.Mapping
{
    public class OrderClassMap : MongoClassMap<Order>
    {
        public override void Map(BsonClassMap<Order> cm)
        {
            cm.MapIdField(x => x.Number);
            cm.MapProperty(x => x.Number)
                .SetElementName("ORDER_NUMBER");

            cm.MapProperty(x => x.PaymentMethodId)
                .SetElementName("PAYMENT_METHOD");

            cm.MapProperty(x => x.DeliveryMethodId)
                .SetElementName("DELIVERY_METHOD");

            cm.MapProperty(x => x.CustomerId)
                .SetElementName("CUSTOMER_ID");

            cm.MapProperty(x => x.FreeDelivery)
                .SetElementName("FREE_DELIVERY");

            cm.MapProperty(x => x.GrossValue)
                .SetElementName("GROSS_VALUE");

            cm.MapProperty(x => x.NetValue)
                .SetElementName("NET_VALUE");

            cm.MapProperty(x => x.TaxValue)
                .SetElementName("TAX_VALUE");

            cm.MapProperty(x => x.Tax)
                .SetElementName("TAX");

            cm.MapProperty(x => x.CreationDate)
                .SetElementName("CREATION_DATE");

            cm.MapProperty(x => x.FulfillmentDate)
                .SetElementName("FULLFILLMENT_DATE");

            cm.MapProperty(x => x.Items)
                .SetElementName("ITEMS");

            cm.UnmapProperty(x => x.PaymentMethod);
            cm.UnmapProperty(x => x.DeliveryMethod);
            cm.UnmapProperty(x => x.Customer);
        }
    }
}