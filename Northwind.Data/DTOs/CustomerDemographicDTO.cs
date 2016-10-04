using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CustomerDemographicDTO : ZDTOBase<CustomerDemographicDTO, CustomerDemographic>
    {
        #region Properties
               
        public virtual string CustomerTypeId { get; set; }
               
        public virtual string CustomerDesc { get; set; }

        #endregion Properties

        #region Methods
        
        public CustomerDemographicDTO()
        {
            CustomerTypeId = LibraryDefaults.Default_String;
            CustomerDesc = null;
        }
        
        public CustomerDemographicDTO(
            string customerTypeId,
            string customerDesc = null
        )
        {
            CustomerTypeId = customerTypeId;
            CustomerDesc = customerDesc;
        }

        public CustomerDemographicDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<CustomerDemographicDTO, CustomerDemographic> GetDataSelector()
        {
            return x => new CustomerDemographic
            {
                CustomerTypeId = x.CustomerTypeId,
                CustomerDesc = x.CustomerDesc
            };
        }

        public override Func<CustomerDemographic, CustomerDemographicDTO> GetDTOSelector()
        {
            return x => new CustomerDemographicDTO
            {
                CustomerTypeId = x.CustomerTypeId,
                CustomerDesc = x.CustomerDesc,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CustomerDemographicDTO dto = (new List<CustomerDemographic> { (CustomerDemographic)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<CustomerDemographicDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
