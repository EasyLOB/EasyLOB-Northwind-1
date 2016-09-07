using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class CustomerCustomerDemoItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public CustomerCustomerDemoViewModel CustomerCustomerDemo { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterCustomerTypeId != null || MasterCustomerId != null;
            }
            set { }
        }

        public string MasterCustomerTypeId { get; set; }

        public string MasterCustomerId { get; set; }

        public CustomerCustomerDemoItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
