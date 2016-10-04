using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class RegionDTO : ZDTOBase<RegionDTO, Region>
    {
        #region Properties
               
        public virtual int RegionId { get; set; }
               
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Methods
        
        public RegionDTO()
        {
            RegionId = LibraryDefaults.Default_Int32;
            RegionDescription = LibraryDefaults.Default_String;
        }
        
        public RegionDTO(
            int regionId,
            string regionDescription
        )
        {
            RegionId = regionId;
            RegionDescription = regionDescription;
        }

        public RegionDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<RegionDTO, Region> GetDataSelector()
        {
            return x => new Region
            {
                RegionId = x.RegionId,
                RegionDescription = x.RegionDescription
            };
        }

        public override Func<Region, RegionDTO> GetDTOSelector()
        {
            return x => new RegionDTO
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
                RegionDTO dto = (new List<Region> { (Region)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<RegionDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
