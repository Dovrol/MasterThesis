using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;

namespace Infrastructure.MongoDB.Configuration
{
    public abstract class MongoClassMap<T>
    {
        protected MongoClassMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}