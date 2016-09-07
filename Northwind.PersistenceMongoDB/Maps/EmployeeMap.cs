using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void EmployeeMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Employee)))
            {            
                BsonClassMap.RegisterClassMap<Employee>(map =>
                {
                    map.MapIdProperty(x => x.EmployeeId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.EmployeeId);
                    map.MapProperty(x => x.LastName);
                    map.MapProperty(x => x.FirstName);
                    map.MapProperty(x => x.Title);
                    map.MapProperty(x => x.TitleOfCourtesy);
                    map.MapProperty(x => x.BirthDate);
                    map.MapProperty(x => x.HireDate);
                    map.MapProperty(x => x.Address);
                    map.MapProperty(x => x.City);
                    map.MapProperty(x => x.Region);
                    map.MapProperty(x => x.PostalCode);
                    map.MapProperty(x => x.Country);
                    map.MapProperty(x => x.HomePhone);
                    map.MapProperty(x => x.Extension);
                    map.MapProperty(x => x.Photo);
                    map.MapProperty(x => x.Notes);
                    map.MapProperty(x => x.ReportsTo);
                    map.MapProperty(x => x.PhotoPath);
                });
            }
        }
    }
}
