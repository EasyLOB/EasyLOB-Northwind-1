using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeTerritoryRepositoryRedis : NorthwindGenericRepositoryRedis<EmployeeTerritory>
    {
        #region Methods

        public NorthwindEmployeeTerritoryRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(EmployeeTerritory employeeTerritory)
        {
            if (employeeTerritory != null)
            {
                employeeTerritory.Employee = UnitOfWork.GetRepository<Employee>().GetById(employeeTerritory.EmployeeId);
                employeeTerritory.Territory = UnitOfWork.GetRepository<Territory>().GetById(employeeTerritory.TerritoryId);
            }
        }

        #endregion Methods
    }
}
