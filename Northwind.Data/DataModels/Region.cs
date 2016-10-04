using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { },
        collections: new string[] { "Territories" },
        isIdentity: false,
        keys: new string[] { "RegionId" },
        linqOrderBy: "RegionDescription",
        linqWhere: "RegionId == @0",
        lookup: "RegionDescription"
    )]    
    public partial class Region : ZDataBase
    {        
        #region Properties
        
        public virtual int RegionId { get; set; }
        
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Collections (PK)

        public virtual IList<Territory> Territories { get; }

        #endregion Collections (PK)

        #region Methods
        
        public Region()
        {            
            RegionId = LibraryDefaults.Default_Int32;
            RegionDescription = LibraryDefaults.Default_String;

            Territories = new List<Territory>();
        }

        public Region(int regionId)
            : this()
        {            
            RegionId = regionId;
        }

        public Region(
            int regionId,
            string regionDescription
        )
            : this()
        {
            RegionId = regionId;
            RegionDescription = regionDescription;
        }

        public override object[] GetId()
        {
            return new object[] { RegionId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                RegionId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
