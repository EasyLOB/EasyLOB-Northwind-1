﻿using EasyLOB.Library;
using EasyLOB.Security;

namespace EasyLOB.AuditTrail.Mvc
{
    public partial class AuditTrailLogCollectionModel
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

        public AuditTrailLogCollectionModel()
        {
            OperationResult = new ZOperationResult();
        }
    }
}
