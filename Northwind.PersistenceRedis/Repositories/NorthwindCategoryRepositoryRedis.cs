using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindCategoryRepositoryRedis : NorthwindGenericRepositoryRedis<Category>
    {
        #region Methods

        public NorthwindCategoryRepositoryRedis(IUnitOfWork unitOfWork)
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
