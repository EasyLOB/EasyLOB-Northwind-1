using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindOrderRepositoryRedis : NorthwindGenericRepositoryRedis<Order>
    {
        #region Methods

        public NorthwindOrderRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Order order)
        {
            if (order != null)
            {
                order.Customer = UnitOfWork.GetRepository<Customer>().GetById(order.CustomerId);
                order.Employee = UnitOfWork.GetRepository<Employee>().GetById(order.EmployeeId);
                order.Shipper = UnitOfWork.GetRepository<Shipper>().GetById(order.ShipVia);
            }
        }

        #endregion Methods
    }
}
