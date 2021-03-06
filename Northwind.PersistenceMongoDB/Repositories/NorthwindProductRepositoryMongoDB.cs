using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindProductRepositoryMongoDB : NorthwindGenericRepositoryMongoDB<Product>
    {
        #region Methods

        public NorthwindProductRepositoryMongoDB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(Product product)
        {
            if (product != null)
            {
                product.Category = UnitOfWork.GetRepository<Category>().GetById(product.CategoryId);
                product.Supplier = UnitOfWork.GetRepository<Supplier>().GetById(product.SupplierId);
            }
        }

        #endregion Methods
    }
}
