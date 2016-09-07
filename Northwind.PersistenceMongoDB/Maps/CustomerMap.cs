using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void CustomerMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Customer)))
            {            
                BsonClassMap.RegisterClassMap<Customer>(map =>
                {
                    map.MapProperty(x => x.CustomerId);
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
                });
            }
        }
    }
}
