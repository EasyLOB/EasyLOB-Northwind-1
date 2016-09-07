using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCustomerDemographicRepositoryRedis : NorthwindGenericRepositoryRedis<CustomerDemographic>
    {
        #region Methods

        public NorthwindCustomerDemographicRepositoryRedis(IUnitOfWork unitOfWork)
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
