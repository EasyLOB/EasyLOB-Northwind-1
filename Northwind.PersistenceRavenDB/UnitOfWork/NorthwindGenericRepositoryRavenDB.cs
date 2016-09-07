using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindGenericRepositoryRavenDB<TEntity> : GenericRepositoryRavenDB<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericRepositoryRavenDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            DocumentStore = (unitOfWork as NorthwindUnitOfWorkRavenDB).DocumentStore;
            DocumentSession = (unitOfWork as NorthwindUnitOfWorkRavenDB).DocumentSession;            
        }

        #endregion Methods
    }
}
