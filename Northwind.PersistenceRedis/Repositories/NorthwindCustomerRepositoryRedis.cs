using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCustomerRepositoryRedis : NorthwindGenericRepositoryRedis<Customer>
    {
        #region Methods

        public NorthwindCustomerRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Customer customer)
        {
            if (customer != null)
            {
            }
        }

        #endregion Methods
    }
}
