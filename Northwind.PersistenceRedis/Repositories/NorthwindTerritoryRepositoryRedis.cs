using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindTerritoryRepositoryRedis : NorthwindGenericRepositoryRedis<Territory>
    {
        #region Methods

        public NorthwindTerritoryRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Territory territory)
        {
            if (territory != null)
            {
                territory.Region = UnitOfWork.GetRepository<Region>().GetById(territory.RegionId);
            }
        }

        #endregion Methods
    }
}
