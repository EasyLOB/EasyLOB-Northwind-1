using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeRepositoryRedis : NorthwindGenericRepositoryRedis<Employee>
    {
        #region Methods

        public NorthwindEmployeeRepositoryRedis(IUnitOfWork unitOfWork)
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
