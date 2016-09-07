using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindOrderRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Order>
    {
        #region Methods

        public NorthwindOrderRepositoryMongoDB(IUnitOfWork unitOfWork)
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
