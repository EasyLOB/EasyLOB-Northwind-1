using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class CategoryItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public CategoryViewModel Category { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return false;
            }
            set { }
        }

        public CategoryItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
