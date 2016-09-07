using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCustomerRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Customer>
    {
        #region Methods

        public NorthwindCustomerRepositoryMongoDB(IUnitOfWork unitOfWork)
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
