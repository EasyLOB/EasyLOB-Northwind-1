using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindRegionRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Region>
    {
        #region Methods

        public NorthwindRegionRepositoryMongoDB(IUnitOfWork unitOfWork)
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
