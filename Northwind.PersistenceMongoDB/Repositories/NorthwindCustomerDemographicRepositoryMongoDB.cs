using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCustomerDemographicRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<CustomerDemographic>
    {
        #region Methods

        public NorthwindCustomerDemographicRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(CustomerDemographic customerDemographic)
        {
            if (customerDemographic != null)
            {
            }
        }

        #endregion Methods
    }
}
