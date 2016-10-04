using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CategoryDTO : ZDTOBase<CategoryDTO, Category>
    {
        #region Properties
               
        public virtual int CategoryId { get; set; }
               
        public virtual string CategoryName { get; set; }
               
        public virtual string Description { get; set; }
               
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Methods
        
        public CategoryDTO()
        {
            CategoryId = LibraryDefaults.Default_Int32;
            CategoryName = LibraryDefaults.Default_String;
            Description = null;
            Picture = null;
        }
        
        public CategoryDTO(
            int categoryId,
            string categoryName,
            string description = null,
            byte[] picture = null
        )
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Picture = picture;
        }

        public CategoryDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<CategoryDTO, Category> GetDataSelector()
        {
            return x => new Category
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture
            };
        }

        public override Func<Category, CategoryDTO> GetDTOSelector()
        {
            return x => new CategoryDTO
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CategoryDTO dto = (new List<Category> { (Category)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<CategoryDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
