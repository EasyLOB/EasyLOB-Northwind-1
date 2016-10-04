using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class ShipperDTO : ZDTOBase<ShipperDTO, Shipper>
    {
        #region Properties
               
        public virtual int ShipperId { get; set; }
               
        public virtual string CompanyName { get; set; }
               
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Methods
        
        public ShipperDTO()
        {
            ShipperId = LibraryDefaults.Default_Int32;
            CompanyName = LibraryDefaults.Default_String;
            Phone = null;
        }
        
        public ShipperDTO(
            int shipperId,
            string companyName,
            string phone = null
        )
        {
            ShipperId = shipperId;
            CompanyName = companyName;
            Phone = phone;
        }

        public ShipperDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<ShipperDTO, Shipper> GetDataSelector()
        {
            return x => new Shipper
            {
                ShipperId = x.ShipperId,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            };
        }

        public override Func<Shipper, ShipperDTO> GetDTOSelector()
        {
            return x => new ShipperDTO
            {
                ShipperId = x.ShipperId,
                CompanyName = x.CompanyName,
                Phone = x.Phone,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                ShipperDTO dto = (new List<Shipper> { (Shipper)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<ShipperDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
