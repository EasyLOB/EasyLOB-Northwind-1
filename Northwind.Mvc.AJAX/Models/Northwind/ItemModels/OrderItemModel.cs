using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class OrderItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public OrderViewModel Order { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterCustomerId != null || MasterEmployeeId != null || MasterShipVia != null;
            }
            set { }
        }

        public string MasterCustomerId { get; set; }

        public int? MasterEmployeeId { get; set; }

        public int? MasterShipVia { get; set; }

        public OrderItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
