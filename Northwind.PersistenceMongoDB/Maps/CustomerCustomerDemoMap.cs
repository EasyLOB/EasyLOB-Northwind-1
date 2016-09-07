using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void CustomerCustomerDemoMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(CustomerCustomerDemo)))
            {            
                BsonClassMap.RegisterClassMap<CustomerCustomerDemo>(map =>
                {
                    map.MapProperty(x => x.CustomerId);
                    map.MapProperty(x => x.CustomerTypeId);
                });
            }
        }
    }
}
