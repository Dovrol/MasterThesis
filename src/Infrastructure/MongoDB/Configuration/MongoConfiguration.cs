using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Infrastructure.MongoDB.Configuration
{
    public class MongoConfiguration
    {
        public static void RegisterDocumentMaps()
        {
            var assembly = Assembly.GetAssembly(typeof(Extensions));
            
            var classMaps = assembly?.GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                    t.BaseType.GetGenericTypeDefinition() == typeof(MongoClassMap<>));
            
            // classMaps?.Select(x => Activator.CreateInstance(x));    
            foreach (var map in classMaps)
            {
                Activator.CreateInstance(map);
            }            
        }

        public static void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new ImmutableTypeClassMapConvention()
            };
            
            ConventionRegistry.Register("Conventions", pack, t => true);
        }
        public static void RegisterGlobalSerializers()
        {
            // BsonSerializer.RegisterSerializationProvider(new SmartEnumSerializationProvider());
            // BsonSerializer.RegisterSerializer(typeof(ExerciseSpecification), new ExerciseSpecificationSerializer());
        }
    }
}