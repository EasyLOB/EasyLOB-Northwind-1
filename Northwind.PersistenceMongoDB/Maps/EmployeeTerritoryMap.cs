using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void EmployeeTerritoryMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(EmployeeTerritory)))
            {            
                BsonClassMap.RegisterClassMap<EmployeeTerritory>(map =>
                {
                    map.MapProperty(x => x.EmployeeId);
                    map.MapProperty(x => x.TerritoryId);
                });
            }
        }
    }
}
