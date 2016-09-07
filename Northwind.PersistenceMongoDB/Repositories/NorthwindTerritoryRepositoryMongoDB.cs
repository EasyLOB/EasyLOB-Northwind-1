using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindTerritoryRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Territory>
    {
        #region Methods

        public NorthwindTerritoryRepositoryMongoDB(IUnitOfWork unitOfWork)
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
