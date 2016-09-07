using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeTerritoryRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<EmployeeTerritory>
    {
        #region Methods

        public NorthwindEmployeeTerritoryRepositoryMongoDB(IUnitOfWork unitOfWork)
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
