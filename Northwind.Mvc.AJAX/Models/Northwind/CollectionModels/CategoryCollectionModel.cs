using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class CategoryCollectionModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public string ControllerAction { get; set; }

        public string MasterControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return false;
            }
            set { }
        }

        public CategoryCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
