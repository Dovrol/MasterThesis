using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Infrastructure.MongoDB.Configuration.Mapping
{
    public class OrderItemClassMap : MongoClassMap<OrderItem>
    {
        public override void Map(BsonClassMap<OrderItem> cm)
        {
            cm.MapProperty(x => x.Position)
                .SetElementName("POSITION");

            cm.MapProperty(x => x.Name)
                .SetElementName("NAME");

            cm.MapProperty(x => x.NetValue)
                .SetElementName("NET_VALUE");

            cm.UnmapProperty(x => x.Order);
            cm.UnmapProperty(x => x.OrderId);
        }
    }
}