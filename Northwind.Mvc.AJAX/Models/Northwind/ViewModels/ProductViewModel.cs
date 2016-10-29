using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Mvc
{
    public partial class ProductViewModel : ZViewBase<ProductViewModel, ProductDTO, Product>
    {
        #region Properties
        
        [Display(Name = "PropertyProductId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int ProductId { get; set; }
        
        [Display(Name = "PropertyProductName", ResourceType = typeof(ProductResources))]
        [Required]
        [StringLength(40)]
        public virtual string ProductName { get; set; }
        
        [Display(Name = "PropertySupplierId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? SupplierId { get; set; }
        
        [Display(Name = "PropertyCategoryId", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual int? CategoryId { get; set; }
        
        [Display(Name = "PropertyQuantityPerUnit", ResourceType = typeof(ProductResources))]
        [StringLength(20)]
        public virtual string QuantityPerUnit { get; set; }
        
        [Display(Name = "PropertyUnitPrice", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        public virtual decimal? UnitPrice { get; set; }
        
        [Display(Name = "PropertyUnitsInStock", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? UnitsInStock { get; set; }
        
        [Display(Name = "PropertyUnitsOnOrder", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? UnitsOnOrder { get; set; }
        
        [Display(Name = "PropertyReorderLevel", ResourceType = typeof(ProductResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public virtual short? ReorderLevel { get; set; }
        
        [Display(Name = "PropertyDiscontinued", ResourceType = typeof(ProductResources))]
        [Required]
        public virtual bool Discontinued { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CategoryLookupText { get; set; } // CategoryId

        public virtual string SupplierLookupText { get; set; } // SupplierId
    
        #endregion Associations FK

        #region Methods
        
        public ProductViewModel()
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
        
        public ProductViewModel(
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
            : this()
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

        public ProductViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public ProductViewModel(IZDTOBase<ProductDTO, Product> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<ProductViewModel, ProductDTO> GetDTOSelector()
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
                Discontinued = x.Discontinued
            };
        }

        public override Func<ProductDTO, ProductViewModel> GetViewSelector()
        {
            return x => new ProductViewModel
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
                CategoryLookupText = x.CategoryLookupText,
                SupplierLookupText = x.SupplierLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                ProductDTO dto = new ProductDTO(data);
                ProductViewModel view = (new List<ProductDTO> { (ProductDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<ProductDTO, Product> dto)
        {
            if (dto != null)
            {
                ProductViewModel view = (new List<ProductDTO> { (ProductDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<ProductDTO, Product> ToDTO()
        {
            return (new List<ProductViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
