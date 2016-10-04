using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CustomerCustomerDemoDTO : ZDTOBase<CustomerCustomerDemoDTO, CustomerCustomerDemo>
    {
        #region Properties
               
        public virtual string CustomerId { get; set; }
               
        public virtual string CustomerTypeId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerDemographicLookupText { get; set; } // CustomerTypeId

        public virtual string CustomerLookupText { get; set; } // CustomerId
    
        #endregion Associations FK

        #region Methods
        
        public CustomerCustomerDemoDTO()
        {
            CustomerId = LibraryDefaults.Default_String;
            CustomerTypeId = LibraryDefaults.Default_String;
        }
        
        public CustomerCustomerDemoDTO(
            string customerId,
            string customerTypeId,
            string customerDemographicLookupText = null,
            string customerLookupText = null
        )
        {
            CustomerId = customerId;
            CustomerTypeId = customerTypeId;
            CustomerDemographicLookupText = customerDemographicLookupText;
            CustomerLookupText = customerLookupText;
        }

        public CustomerCustomerDemoDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<CustomerCustomerDemoDTO, CustomerCustomerDemo> GetDataSelector()
        {
            return x => new CustomerCustomerDemo
            {
                CustomerId = x.CustomerId,
                CustomerTypeId = x.CustomerTypeId
            };
        }

        public override Func<CustomerCustomerDemo, CustomerCustomerDemoDTO> GetDTOSelector()
        {
            return x => new CustomerCustomerDemoDTO
            {
                CustomerId = x.CustomerId,
                CustomerTypeId = x.CustomerTypeId,
                CustomerDemographicLookupText = x.CustomerDemographic == null ? "" : x.CustomerDemographic.LookupText,
                CustomerLookupText = x.Customer == null ? "" : x.Customer.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CustomerCustomerDemoDTO dto = (new List<CustomerCustomerDemo> { (CustomerCustomerDemo)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<CustomerCustomerDemoDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
