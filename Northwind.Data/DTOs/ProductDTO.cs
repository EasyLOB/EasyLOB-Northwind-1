using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class ProductDTO : ZDTOBase<ProductDTO, Product>
    {
        #region Properties
               
        public virtual int ProductId { get; set; }
               
        public virtual string ProductName { get; set; }
               
        public virtual int? SupplierId { get; set; }
               
        public virtual int? CategoryId { get; set; }
               
        public virtual string QuantityPerUnit { get; set; }
               
        public virtual decimal? UnitPrice { get; set; }
               
        public virtual short? UnitsInStock { get; set; }
               
        public virtual short? UnitsOnOrder { get; set; }
               
        public virtual short? ReorderLevel { get; set; }
               
        public virtual bool Discontinued { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CategoryLookupText { get; set; } // CategoryId

        public virtual string SupplierLookupText { get; set; } // SupplierId
    
        #endregion Associations FK

        #region Methods
        
        public ProductDTO()
        {
            ProductId = LibraryDefaults.Default_Int32;
            ProductName = LibraryDefaults.Default_String;
            Discontinued = LibraryDefaults.Default_Boolean;
            SupplierId = null;
            CategoryId = null;
            QuantityPerUnit = null;
            UnitPrice = null;
            UnitsInStock = null;
            UnitsOnOrder = null;
            ReorderLevel = null;
        }
        
        public ProductDTO(
            int productId,
            string productName,
            bool discontinued,
            int? supplierId = null,
            int? categoryId = null,
            string quantityPerUnit = null,
            decimal? unitPrice = null,
            short? unitsInStock = null,
            short? unitsOnOrder = null,
            short? reorderLevel = null,
            string categoryLookupText = null,
            string supplierLookupText = null
        )
        {
            ProductId = productId;
            ProductName = productName;
            SupplierId = supplierId;
            CategoryId = categoryId;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
            CategoryLookupText = categoryLookupText;
            SupplierLookupText = supplierLookupText;
        }

        public ProductDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<ProductDTO, Product> GetDataSelector()
        {
            return x => new Product
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SupplierId = x.SupplierId,
                CategoryId = x.CategoryId,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            };
        }

        public override Func<Product, ProductDTO> GetDTOSelector()
        {
            return x => new ProductDTO
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SupplierId = x.SupplierId,
                CategoryId = x.CategoryId,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued,
                CategoryLookupText = x.Category == null ? "" : x.Category.LookupText,
                SupplierLookupText = x.Supplier == null ? "" : x.Supplier.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                ProductDTO dto = (new List<Product> { (Product)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<ProductDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
