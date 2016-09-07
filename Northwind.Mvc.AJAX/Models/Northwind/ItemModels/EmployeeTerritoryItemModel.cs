using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class EmployeeTerritoryItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public EmployeeTerritoryViewModel EmployeeTerritory { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterEmployeeId != null || MasterTerritoryId != null;
            }
            set { }
        }

        public int? MasterEmployeeId { get; set; }

        public string MasterTerritoryId { get; set; }

        public EmployeeTerritoryItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
