using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void ProductMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Product)))
            {            
                BsonClassMap.RegisterClassMap<Product>(map =>
                {
                    map.MapIdProperty(x => x.ProductId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.ProductId);
                    map.MapProperty(x => x.ProductName);
                    map.MapProperty(x => x.SupplierId);
                    map.MapProperty(x => x.CategoryId);
                    map.MapProperty(x => x.QuantityPerUnit);
                    map.MapProperty(x => x.UnitPrice);
                    map.MapProperty(x => x.UnitsInStock);
                    map.MapProperty(x => x.UnitsOnOrder);
                    map.MapProperty(x => x.ReorderLevel);
                    map.MapProperty(x => x.Discontinued);
                });
            }
        }
    }
}
