using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void ShipperMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Shipper)))
            {            
                BsonClassMap.RegisterClassMap<Shipper>(map =>
                {
                    map.MapIdProperty(x => x.ShipperId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.ShipperId);
                    map.MapProperty(x => x.CompanyName);
                    map.MapProperty(x => x.Phone);
                });
            }
        }
    }
}
