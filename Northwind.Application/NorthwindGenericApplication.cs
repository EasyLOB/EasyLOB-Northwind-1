using Northwind.Persistence;
using EasyLOB.Application;
using EasyLOB.AuditTrail;
using EasyLOB.Data;
using EasyLOB.Log;
using EasyLOB.Security;

namespace Northwind.Application
{
    public class NorthwindGenericApplication<TEntity>
        : GenericApplication<TEntity>, INorthwindGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericApplication(INorthwindUnitOfWork unitOfWork, IAuditTrailManager auditTrailManager, ILogManager logManager, ISecurityManager securityManager)
            : base(unitOfWork, auditTrailManager, logManager, securityManager)
        {
        }

        #endregion Methods
    }
}