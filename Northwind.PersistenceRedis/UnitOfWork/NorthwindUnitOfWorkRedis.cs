using ServiceStack;
using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindUnitOfWorkRedis : UnitOfWorkRedis, INorthwindUnitOfWork
    {
        #region Methods

        public NorthwindUnitOfWorkRedis()
            : base(LibraryHelper.AppSettings<string>("Redis.Northwind"))
        {           
            Domain = "Northwind";

            ModelConfig<Category>.Id(x => x.CategoryId);
            ModelConfig<CustomerCustomerDemo>.Id(x => x.CustomerId);
            ModelConfig<CustomerDemographic>.Id(x => x.CustomerTypeId);
            ModelConfig<Customer>.Id(x => x.CustomerId);
            ModelConfig<Employee>.Id(x => x.EmployeeId);
            ModelConfig<EmployeeTerritory>.Id(x => x.EmployeeId);
            ModelConfig<OrderDetail>.Id(x => x.OrderId);
            ModelConfig<Order>.Id(x => x.OrderId);
            ModelConfig<Product>.Id(x => x.ProductId);
            ModelConfig<Region>.Id(x => x.RegionId);
            ModelConfig<Shipper>.Id(x => x.ShipperId);
            ModelConfig<Supplier>.Id(x => x.SupplierId);
            ModelConfig<Territory>.Id(x => x.TerritoryId);
            
            Repositories.Add(typeof(Category), new NorthwindCategoryRepositoryRedis(this));
            Repositories.Add(typeof(CustomerCustomerDemo), new NorthwindCustomerCustomerDemoRepositoryRedis(this));
            Repositories.Add(typeof(CustomerDemographic), new NorthwindCustomerDemographicRepositoryRedis(this));
            Repositories.Add(typeof(Customer), new NorthwindCustomerRepositoryRedis(this));
            Repositories.Add(typeof(Employee), new NorthwindEmployeeRepositoryRedis(this));
            Repositories.Add(typeof(EmployeeTerritory), new NorthwindEmployeeTerritoryRepositoryRedis(this));
            Repositories.Add(typeof(OrderDetail), new NorthwindOrderDetailRepositoryRedis(this));
            Repositories.Add(typeof(Order), new NorthwindOrderRepositoryRedis(this));
            Repositories.Add(typeof(Product), new NorthwindProductRepositoryRedis(this));
            Repositories.Add(typeof(Region), new NorthwindRegionRepositoryRedis(this));
            Repositories.Add(typeof(Shipper), new NorthwindShipperRepositoryRedis(this));
            Repositories.Add(typeof(Supplier), new NorthwindSupplierRepositoryRedis(this));
            Repositories.Add(typeof(Territory), new NorthwindTerritoryRepositoryRedis(this));

            //IRedisClient client = base.Client;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryRedis<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        #endregion Methods
    }
}

