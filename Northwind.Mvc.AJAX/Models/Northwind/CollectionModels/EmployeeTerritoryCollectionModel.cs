using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class EmployeeTerritoryCollectionModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public string ControllerAction { get; set; }

        public string MasterControllerAction { get; set; }

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

        public EmployeeTerritoryCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
