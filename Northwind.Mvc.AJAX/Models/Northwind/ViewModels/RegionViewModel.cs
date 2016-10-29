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
    public partial class RegionViewModel : ZViewBase<RegionViewModel, RegionDTO, Region>
    {
        #region Properties
        
        [Display(Name = "PropertyRegionId", ResourceType = typeof(RegionResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Required]
        public virtual int RegionId { get; set; }
        
        [Display(Name = "PropertyRegionDescription", ResourceType = typeof(RegionResources))]
        [Required]
        [StringLength(50)]
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Methods
        
        public RegionViewModel()
        {
            RegionId = LibraryDefaults.Default_Int32;
            RegionDescription = LibraryDefaults.Default_String;
        }
        
        public RegionViewModel(
            int regionId,
            string regionDescription
        )
            : this()
        {
            RegionId = regionId;
            RegionDescription = regionDescription;
        }

        public RegionViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public RegionViewModel(IZDTOBase<RegionDTO, Region> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<RegionViewModel, RegionDTO> GetDTOSelector()
        {
            return x => new RegionDTO
            {
                RegionId = x.RegionId,
                RegionDescription = x.RegionDescription
            };
        }

        public override Func<RegionDTO, RegionViewModel> GetViewSelector()
        {
            return x => new RegionViewModel
            {
                RegionId = x.RegionId,
                RegionDescription = x.RegionDescription,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                RegionDTO dto = new RegionDTO(data);
                RegionViewModel view = (new List<RegionDTO> { (RegionDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<RegionDTO, Region> dto)
        {
            if (dto != null)
            {
                RegionViewModel view = (new List<RegionDTO> { (RegionDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<RegionDTO, Region> ToDTO()
        {
            return (new List<RegionViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
