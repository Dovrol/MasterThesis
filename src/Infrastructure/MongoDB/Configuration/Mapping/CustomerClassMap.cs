using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Infrastructure.MongoDB.Configuration.Mapping
{
    public class CustomerClassMap : MongoClassMap<Customer>
    {
        public override void Map(BsonClassMap<Customer> cm)
        {
            cm.MapIdProperty(x => x.Id);
            cm.MapProperty(x => x.Id)
                .SetElementName("ID");

            cm.MapProperty(x => x.FirstName)
                .SetElementName("FIRST_NAME");
            
            cm.MapProperty(x => x.LastName)
                .SetElementName("LAST_NAME");

            cm.MapProperty(x => x.Email)
                .SetElementName("EMAIL");

            cm.MapProperty(x => x.Gender)
                .SetElementName("GENDER");

            cm.UnmapProperty(x => x.Orders);
        }
    }
}