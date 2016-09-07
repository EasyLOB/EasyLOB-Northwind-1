using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindGenericRepositoryRedis<TEntity> : GenericRepositoryRedis<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Client = (unitOfWork as NorthwindUnitOfWorkRedis).Client;
        }

        #endregion Methods
    }
}
