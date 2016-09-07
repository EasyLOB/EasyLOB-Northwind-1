using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class CustomerCustomerDemoCollectionModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public string ControllerAction { get; set; }

        public string MasterControllerAction { get; set; }

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

        public CustomerCustomerDemoCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
