using EasyLOB.Library;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindUnitOfWorkRavenDB : UnitOfWorkRavenDB, INorthwindUnitOfWork
    {
        #region Methods

        public NorthwindUnitOfWorkRavenDB()
            : base(LibraryHelper.AppSettings<string>("RavenDB.Northwind.Url"), LibraryHelper.AppSettings<string>("RavenDB.Northwind.Database"))
        {           
            Domain = "Northwind";

            //IRavenDatabase database = base.Database;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryRavenDB<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        #endregion Methods
    }
}

