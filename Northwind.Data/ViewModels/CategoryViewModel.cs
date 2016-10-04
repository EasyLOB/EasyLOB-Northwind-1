using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CategoryViewModel : ZViewBase<CategoryViewModel, CategoryDTO, Category>
    {
        #region Properties
        
        [Display(Name = "PropertyCategoryId", ResourceType = typeof(CategoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int CategoryId { get; set; }
        
        [Display(Name = "PropertyCategoryName", ResourceType = typeof(CategoryResources))]
        [Required]
        [StringLength(15)]
        public virtual string CategoryName { get; set; }
        
        [Display(Name = "PropertyDescription", ResourceType = typeof(CategoryResources))]
        [StringLength(1024)]
        public virtual string Description { get; set; }
        
        [Display(Name = "PropertyPicture", ResourceType = typeof(CategoryResources))]
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Methods
        
        public CategoryViewModel()
        {
            CategoryId = LibraryDefaults.Default_Int32;
            CategoryName = LibraryDefaults.Default_String;
            Description = null;
            Picture = null;
        }
        
        public CategoryViewModel(
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

        public CategoryViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public CategoryViewModel(IZDTOBase<CategoryDTO, Category> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<CategoryViewModel, CategoryDTO> GetDTOSelector()
        {
            return x => new CategoryDTO
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture
            };
        }

        public override Func<CategoryDTO, CategoryViewModel> GetViewSelector()
        {
            return x => new CategoryViewModel
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
                CategoryDTO dto = new CategoryDTO(data);
                CategoryViewModel view = (new List<CategoryDTO> { (CategoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<CategoryDTO, Category> dto)
        {
            if (dto != null)
            {
                CategoryViewModel view = (new List<CategoryDTO> { (CategoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<CategoryDTO, Category> ToDTO()
        {
            return (new List<CategoryViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
