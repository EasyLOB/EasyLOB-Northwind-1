using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindShipperRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Shipper>
    {
        #region Methods

        public NorthwindShipperRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Shipper shipper)
        {
            if (shipper != null)
            {
            }
        }

        #endregion Methods
    }
}
