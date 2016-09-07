using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Security;

namespace Northwind.Mvc
{
    public partial class CustomerDemographicItemModel
    {
        public ZOperationResult OperationResult { get; set; }

        public ZIsSecurityOperations IsSecurityOperations { get; set; }

        public CustomerDemographicViewModel CustomerDemographic { get; set; }

        public string ControllerAction { get; set; }

        public bool IsMasterDetail
        {
            get
            {
                return false;
            }
            set { }
        }

        public CustomerDemographicItemModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
