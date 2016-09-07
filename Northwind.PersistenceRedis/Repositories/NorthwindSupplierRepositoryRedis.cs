using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindSupplierRepositoryRedis : NorthwindGenericRepositoryRedis<Supplier>
    {
        #region Methods

        public NorthwindSupplierRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Supplier supplier)
        {
            if (supplier != null)
            {
            }
        }

        #endregion Methods
    }
}
