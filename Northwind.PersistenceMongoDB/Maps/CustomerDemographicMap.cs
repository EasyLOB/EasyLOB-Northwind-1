using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void CustomerDemographicMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(CustomerDemographic)))
            {            
                BsonClassMap.RegisterClassMap<CustomerDemographic>(map =>
                {
                    map.MapProperty(x => x.CustomerTypeId);
                    map.MapProperty(x => x.CustomerDesc);
                });
            }
        }
    }
}
