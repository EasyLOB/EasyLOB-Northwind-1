using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Employee>
    {
        #region Methods

        public NorthwindEmployeeRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Employee employee)
        {
            if (employee != null)
            {
                employee.EmployeeReportsTo = UnitOfWork.GetRepository<Employee>().GetById(employee.ReportsTo);
            }
        }

        #endregion Methods
    }
}
