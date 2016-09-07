using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void SupplierMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Supplier)))
            {            
                BsonClassMap.RegisterClassMap<Supplier>(map =>
                {
                    map.MapIdProperty(x => x.SupplierId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.SupplierId);
                    map.MapProperty(x => x.CompanyName);
                    map.MapProperty(x => x.ContactName);
                    map.MapProperty(x => x.ContactTitle);
                    map.MapProperty(x => x.Address);
                    map.MapProperty(x => x.City);
                    map.MapProperty(x => x.Region);
                    map.MapProperty(x => x.PostalCode);
                    map.MapProperty(x => x.Country);
                    map.MapProperty(x => x.Phone);
                    map.MapProperty(x => x.Fax);
                    map.MapProperty(x => x.HomePage);
                });
            }
        }
    }
}
