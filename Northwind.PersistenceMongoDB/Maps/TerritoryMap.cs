using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void TerritoryMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Territory)))
            {            
                BsonClassMap.RegisterClassMap<Territory>(map =>
                {
                    map.MapProperty(x => x.TerritoryId);
                    map.MapProperty(x => x.TerritoryDescription);
                    map.MapProperty(x => x.RegionId);
                });
            }
        }
    }
}
