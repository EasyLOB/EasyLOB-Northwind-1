using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void OrderMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Order)))
            {            
                BsonClassMap.RegisterClassMap<Order>(map =>
                {
                    map.MapIdProperty(x => x.OrderId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.OrderId);
                    map.MapProperty(x => x.CustomerId);
                    map.MapProperty(x => x.EmployeeId);
                    map.MapProperty(x => x.OrderDate);
                    map.MapProperty(x => x.RequiredDate);
                    map.MapProperty(x => x.ShippedDate);
                    map.MapProperty(x => x.ShipVia);
                    map.MapProperty(x => x.Freight);
                    map.MapProperty(x => x.ShipName);
                    map.MapProperty(x => x.ShipAddress);
                    map.MapProperty(x => x.ShipCity);
                    map.MapProperty(x => x.ShipRegion);
                    map.MapProperty(x => x.ShipPostalCode);
                    map.MapProperty(x => x.ShipCountry);
                });
            }
        }
    }
}
