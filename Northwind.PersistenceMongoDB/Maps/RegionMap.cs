using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void RegionMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Region)))
            {            
                BsonClassMap.RegisterClassMap<Region>(map =>
                {
                    map.MapProperty(x => x.RegionId);
                    map.MapProperty(x => x.RegionDescription);
                });
            }
        }
    }
}
