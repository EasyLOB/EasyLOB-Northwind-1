using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class ProductCollectionModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public string ControllerAction { get; set; }

        public string MasterControllerAction { get; set; }

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

        public ProductCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
