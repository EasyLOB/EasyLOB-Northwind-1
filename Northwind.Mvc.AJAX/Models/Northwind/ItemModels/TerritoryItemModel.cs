using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class TerritoryItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public TerritoryViewModel Territory { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return MasterRegionId != null;
            }
            set { }
        }

        public int? MasterRegionId { get; set; }

        public TerritoryItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
