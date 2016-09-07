using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public static partial class NorthwindMongoDBMap
    {
        public static void CategoryMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Category)))
            {            
                BsonClassMap.RegisterClassMap<Category>(map =>
                {
                    map.MapIdProperty(x => x.CategoryId)
                        .SetIdGenerator(MongoDBInt32IdGenerator.Instance)
                        .SetSerializer(new StringSerializer(BsonType.String));

                    map.MapProperty(x => x.CategoryId);
                    map.MapProperty(x => x.CategoryName);
                    map.MapProperty(x => x.Description);
                    map.MapProperty(x => x.Picture);
                });
            }
        }
    }
}
