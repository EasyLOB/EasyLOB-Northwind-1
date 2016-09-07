using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCategoryRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Category>
    {
        #region Methods

        public NorthwindCategoryRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Category category)
        {
            if (category != null)
            {
            }
        }

        #endregion Methods
    }
}
