using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class TerritoryViewModel : ZViewBase<TerritoryViewModel, TerritoryDTO, Territory>
    {
        #region Properties
        
        [Display(Name = "PropertyTerritoryId", ResourceType = typeof(TerritoryResources))]
        //[Key]
        [Required]
        [StringLength(20)]
        public virtual string TerritoryId { get; set; }
        
        [Display(Name = "PropertyTerritoryDescription", ResourceType = typeof(TerritoryResources))]
        [Required]
        [StringLength(50)]
        public virtual string TerritoryDescription { get; set; }
        
        [Display(Name = "PropertyRegionId", ResourceType = typeof(TerritoryResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int RegionId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RegionLookupText { get; set; } // RegionId
    
        #endregion Associations FK

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public TerritoryViewModel()
        {
            TerritoryId = "A";
        }
        
        public TerritoryViewModel(
            string territoryId,
            string territoryDescription,
            int regionId,
            string regionLookupText = null
        )
            : this()
        {
            TerritoryId = territoryId;
            TerritoryDescription = territoryDescription;
            RegionId = regionId;
            RegionLookupText = regionLookupText;
        }

        public TerritoryViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public TerritoryViewModel(IZDTOBase<TerritoryDTO, Territory> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<TerritoryViewModel, TerritoryDTO> GetDTOSelector()
        {
            return x => new TerritoryDTO
            {
                TerritoryId = x.TerritoryId,
                TerritoryDescription = x.TerritoryDescription,
                RegionId = x.RegionId,
                RegionLookupText = x.RegionLookupText,
                LookupText = x.LookupText
            };
        }

        public override Func<TerritoryDTO, TerritoryViewModel> GetViewSelector()
        {
            return x => new TerritoryViewModel
            {
                TerritoryId = x.TerritoryId,
                TerritoryDescription = x.TerritoryDescription,
                RegionId = x.RegionId,
                RegionLookupText = x.RegionLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                TerritoryDTO dto = new TerritoryDTO(data);
                TerritoryViewModel view = (new List<TerritoryDTO> { (TerritoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<TerritoryDTO, Territory> dto)
        {
            if (dto != null)
            {
                TerritoryViewModel view = (new List<TerritoryDTO> { (TerritoryDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<TerritoryDTO, Territory> ToDTO()
        {
            return (new List<TerritoryViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
