using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class OrderDetailItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public OrderDetailViewModel OrderDetail { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterOrderId != null || MasterProductId != null;
            }
            set { }
        }

        public int? MasterOrderId { get; set; }

        public int? MasterProductId { get; set; }

        public OrderDetailItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
