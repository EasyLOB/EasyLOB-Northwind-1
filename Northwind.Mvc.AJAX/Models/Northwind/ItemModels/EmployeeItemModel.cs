using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class EmployeeItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public EmployeeViewModel Employee { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterReportsTo != null;
            }
            set { }
        }

        public int? MasterReportsTo { get; set; }

        public EmployeeItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
