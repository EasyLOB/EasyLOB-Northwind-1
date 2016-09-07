using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindGenericRepositoryMongoDB<TEntity> : GenericRepositoryMongoDB<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Database = (unitOfWork as NorthwindUnitOfWorkMongoDB).Database;
        }

        #endregion Methods
    }
}
