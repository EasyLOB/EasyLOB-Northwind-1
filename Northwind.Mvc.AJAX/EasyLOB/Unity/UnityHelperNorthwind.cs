using Northwind.Application;
using Northwind.Persistence;
using Microsoft.Practices.Unity;

namespace EasyLOB
{
    public static class UnityHelperNorthwind
    {
        public static void RegisterMappings(IUnityContainer container)
        {
            container.RegisterType(typeof(INorthwindGenericApplication<>), typeof(NorthwindGenericApplication<>));
            container.RegisterType(typeof(INorthwindGenericApplicationDTO<,>), typeof(NorthwindGenericApplicationDTO<,>));

            // Entity Framework
            container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkEF));
            container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryEF<>));

            // LINQ to DB
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkLINQ2DB));
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryLINQ2DB<>));

            // MongoDB
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkMongoDB));
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryMongoDB<>));

            // NHibernate
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkNH));
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryNH<>));

            // RavenDB
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkRavenDB));
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryRavenDB<>));

            // Redis
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkRedis));
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryRedis<>));
        }
    }
}