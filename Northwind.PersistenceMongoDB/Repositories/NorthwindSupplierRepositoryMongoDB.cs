using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindSupplierRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Supplier>
    {
        #region Methods

        public NorthwindSupplierRepositoryMongoDB(IUnitOfWork unitOfWork)
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
