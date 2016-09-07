using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class ProductItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public ProductViewModel Product { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterCategoryId != null || MasterSupplierId != null;
            }
            set { }
        }

        public int? MasterCategoryId { get; set; }

        public int? MasterSupplierId { get; set; }

        public ProductItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
