using Northwind.Data;
using EasyLOB.Library;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindUnitOfWorkMongoDB : UnitOfWorkMongoDB, INorthwindUnitOfWork
    {
        #region Methods

        public NorthwindUnitOfWorkMongoDB()
            : base(LibraryHelper.AppSettings<string>("MongoDB.Northwind.Url"), LibraryHelper.AppSettings<string>("MongoDB.Northwind.Database"))
        {           
            Domain = "Northwind";

            NorthwindMongoDBMap.CategoryMap();
            NorthwindMongoDBMap.CustomerCustomerDemoMap();
            NorthwindMongoDBMap.CustomerDemographicMap();
            NorthwindMongoDBMap.CustomerMap();
            NorthwindMongoDBMap.EmployeeMap();
            NorthwindMongoDBMap.EmployeeTerritoryMap();
            NorthwindMongoDBMap.OrderDetailMap();
            NorthwindMongoDBMap.OrderMap();
            NorthwindMongoDBMap.ProductMap();
            NorthwindMongoDBMap.RegionMap();
            NorthwindMongoDBMap.ShipperMap();
            NorthwindMongoDBMap.SupplierMap();
            NorthwindMongoDBMap.TerritoryMap();
            
            Repositories.Add(typeof(Category), new NorthwindCategoryRepositoryMongoDB(this));
            Repositories.Add(typeof(CustomerCustomerDemo), new NorthwindCustomerCustomerDemoRepositoryMongoDB(this));
            Repositories.Add(typeof(CustomerDemographic), new NorthwindCustomerDemographicRepositoryMongoDB(this));
            Repositories.Add(typeof(Customer), new NorthwindCustomerRepositoryMongoDB(this));
            Repositories.Add(typeof(Employee), new NorthwindEmployeeRepositoryMongoDB(this));
            Repositories.Add(typeof(EmployeeTerritory), new NorthwindEmployeeTerritoryRepositoryMongoDB(this));
            Repositories.Add(typeof(OrderDetail), new NorthwindOrderDetailRepositoryMongoDB(this));
            Repositories.Add(typeof(Order), new NorthwindOrderRepositoryMongoDB(this));
            Repositories.Add(typeof(Product), new NorthwindProductRepositoryMongoDB(this));
            Repositories.Add(typeof(Region), new NorthwindRegionRepositoryMongoDB(this));
            Repositories.Add(typeof(Shipper), new NorthwindShipperRepositoryMongoDB(this));
            Repositories.Add(typeof(Supplier), new NorthwindSupplierRepositoryMongoDB(this));
            Repositories.Add(typeof(Territory), new NorthwindTerritoryRepositoryMongoDB(this));

            //IMongoDatabase database = base.Database;            
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new NorthwindGenericRepositoryMongoDB<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        #endregion Methods
    }
}

