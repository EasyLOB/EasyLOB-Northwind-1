using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { "Region" },
        collections: new string[] { "EmployeeTerritories" },
        isIdentity: false,
        keys: new string[] { "TerritoryId" },
        linqOrderBy: "TerritoryDescription",
        linqWhere: "TerritoryId == @0",
        lookup: "TerritoryDescription"
    )]    
    public partial class Territory : ZDataBase
    {        
        #region Properties
        
        public virtual string TerritoryId { get; set; }
        
        public virtual string TerritoryDescription { get; set; }
        
        private int _regionId;
        
        public virtual int RegionId
        {
            get { return this.Region == null ? _regionId : this.Region.RegionId; }
            set
            {
                _regionId = value;
                Region = null;
            }
        }

        #endregion Properties

        #region Properties ZDataBase

        public override string LookupText
        {
            get { return base.LookupText; }
            set { }
        }

        #endregion Properties ZDataBase

        #region Associations (FK)

        public virtual Region Region { get; set; } // RegionId

        #endregion Associations FK

        #region Collections (PK)

        public virtual IList<EmployeeTerritory> EmployeeTerritories { get; set; }

        #endregion Collections (PK)

        #region Methods
        
        public Territory()
        {            
            TerritoryId = LibraryDefaults.Default_String;
            TerritoryDescription = LibraryDefaults.Default_String;
            RegionId = LibraryDefaults.Default_Int32;

            //Region = new Region();

            EmployeeTerritories = new List<EmployeeTerritory>();
        }

        public Territory(string territoryId)
            : this()
        {            
            TerritoryId = territoryId;
        }

        public Territory(
            string territoryId,
            string territoryDescription,
            int regionId
        )
            : this()
        {
            TerritoryId = territoryId;
            TerritoryDescription = territoryDescription;
            RegionId = regionId;
        }

        public override object[] GetId()
        {
            return new object[] { TerritoryId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                TerritoryId = DataHelper.IdToString(ids[0]);
            }
        }

        #endregion Methods
    }
}
