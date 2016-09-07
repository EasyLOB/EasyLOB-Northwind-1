using System;
using System.Collections.Generic;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    [ZDataDictionaryAttribute(
        associations: new string[] { },
        collections: new string[] { "Orders" },
        isIdentity: true,
        keys: new string[] { "ShipperId" },
        linqOrderBy: "CompanyName",
        linqWhere: "ShipperId == @0",
        lookup: "CompanyName"
    )]    
    public partial class Shipper : ZDataBase
    {        
        #region Properties
        
        public virtual int ShipperId { get; set; }
        
        public virtual string CompanyName { get; set; }
        
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Properties ZDataBase

        public override string LookupText
        {
            get { return base.LookupText; }
            set { }
        }

        #endregion Properties ZDataBase

        #region Collections (PK)

        public virtual IList<Order> Orders { get; set; }

        #endregion Collections (PK)

        #region Methods
        
        public Shipper()
        {            
            ShipperId = LibraryDefaults.Default_Int32;
            CompanyName = LibraryDefaults.Default_String;
            Phone = null;

            Orders = new List<Order>();
        }

        public Shipper(int shipperId)
            : this()
        {            
            ShipperId = shipperId;
        }

        public Shipper(
            int shipperId,
            string companyName,
            string phone = null
        )
            : this()
        {
            ShipperId = shipperId;
            CompanyName = companyName;
            Phone = phone;
        }

        public override object[] GetId()
        {
            return new object[] { ShipperId };
        }

        public override void SetId(object[] ids)
        {
            if (ids != null && ids[0] != null)
            {
                ShipperId = DataHelper.IdToInt32(ids[0]);
            }
        }

        #endregion Methods
    }
}
