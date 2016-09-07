using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindShipperRepositoryRedis : NorthwindGenericRepositoryRedis<Shipper>
    {
        #region Methods

        public NorthwindShipperRepositoryRedis(IUnitOfWork unitOfWork)
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
