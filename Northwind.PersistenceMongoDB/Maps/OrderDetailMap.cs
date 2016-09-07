using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void OrderDetailMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(OrderDetail)))
            {            
                BsonClassMap.RegisterClassMap<OrderDetail>(map =>
                {
                    map.MapProperty(x => x.OrderId);
                    map.MapProperty(x => x.ProductId);
                    map.MapProperty(x => x.UnitPrice);
                    map.MapProperty(x => x.Quantity);
                    map.MapProperty(x => x.Discount);
                });
            }
        }
    }
}
