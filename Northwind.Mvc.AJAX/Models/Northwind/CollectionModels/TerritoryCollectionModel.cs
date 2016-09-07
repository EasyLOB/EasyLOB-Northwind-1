using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class TerritoryCollectionModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public string ControllerAction { get; set; }

        public string MasterControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterRegionId != null;
            }
            set { }
        }

        public int? MasterRegionId { get; set; }

        public TerritoryCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
