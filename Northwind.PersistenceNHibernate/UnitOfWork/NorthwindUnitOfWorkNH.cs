using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindUnitOfWorkNH : UnitOfWorkNH, INorthwindUnitOfWork
    {
        #region Methods
        
        public NorthwindUnitOfWorkNH()
            : base(NorthwindFactory.Session)
        {
            Domain = "Northwind";

            //ISession session = base.Session;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryNH<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }
        
        #endregion Methods        
    }
}
