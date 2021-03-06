using Northwind.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindOrderDetailRepositoryRedis : NorthwindGenericRepositoryRedis<OrderDetail>
    {
        #region Methods

        public NorthwindOrderDetailRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(OrderDetail orderDetail)
        {
            if (orderDetail != null)
            {
                orderDetail.Order = UnitOfWork.GetRepository<Order>().GetById(orderDetail.OrderId);
                orderDetail.Product = UnitOfWork.GetRepository<Product>().GetById(orderDetail.ProductId);
            }
        }

        #endregion Methods
    }
}
