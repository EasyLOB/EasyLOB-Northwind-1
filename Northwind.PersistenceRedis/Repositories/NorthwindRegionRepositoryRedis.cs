using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindRegionRepositoryRedis : NorthwindGenericRepositoryRedis<Region>
    {
        #region Methods

        public NorthwindRegionRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Region region)
        {
            if (region != null)
            {
            }
        }

        #endregion Methods
    }
}
