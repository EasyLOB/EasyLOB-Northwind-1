using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class TerritoryDTO : ZDTOBase<TerritoryDTO, Territory>
    {
        #region Properties
               
        public virtual string TerritoryId { get; set; }
               
        public virtual string TerritoryDescription { get; set; }
               
        public virtual int RegionId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string RegionLookupText { get; set; } // RegionId
    
        #endregion Associations FK

        #region Properties ZDTOBase

        public override string LookupText { get; set; }

        #endregion Properties ZDTOBase

        #region Methods
        
        public TerritoryDTO()
        {
        }
        
        public TerritoryDTO(
            string territoryId,
            string territoryDescription,
            int regionId,
            string regionLookupText = null
        )
        {
            TerritoryId = territoryId;
            TerritoryDescription = territoryDescription;
            RegionId = regionId;
            RegionLookupText = regionLookupText;
        }

        public TerritoryDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<TerritoryDTO, Territory> GetDataSelector()
        {
            return x => new Territory
            {
                TerritoryId = x.TerritoryId,
                TerritoryDescription = x.TerritoryDescription,
                RegionId = x.RegionId
            };
        }

        public override Func<Territory, TerritoryDTO> GetDTOSelector()
        {
            return x => new TerritoryDTO
            {
                TerritoryId = x.TerritoryId,
                TerritoryDescription = x.TerritoryDescription,
                RegionId = x.RegionId,
                RegionLookupText = x.Region == null ? "" : x.Region.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                TerritoryDTO dto = (new List<Territory> { (Territory)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<TerritoryDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
