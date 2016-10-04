using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CustomerCustomerDemoViewModel : ZViewBase<CustomerCustomerDemoViewModel, CustomerCustomerDemoDTO, CustomerCustomerDemo>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerId", ResourceType = typeof(CustomerCustomerDemoResources))]
        //[Key]
        //[Column(Order=1)]
        [Required]
        [StringLength(5)]
        public virtual string CustomerId { get; set; }
        
        [Display(Name = "PropertyCustomerTypeId", ResourceType = typeof(CustomerCustomerDemoResources))]
        //[Key]
        //[Column(Order=2)]
        [Required]
        [StringLength(10)]
        public virtual string CustomerTypeId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerDemographicLookupText { get; set; } // CustomerTypeId

        public virtual string CustomerLookupText { get; set; } // CustomerId
    
        #endregion Associations FK

        #region Methods
        
        public CustomerCustomerDemoViewModel()
        {
            CustomerId = LibraryDefaults.Default_String;
            CustomerTypeId = LibraryDefaults.Default_String;
        }
        
        public CustomerCustomerDemoViewModel(
            string customerId,
            string customerTypeId,
            string customerDemographicLookupText = null,
            string customerLookupText = null
        )
            : this()
        {
            CustomerId = customerId;
            CustomerTypeId = customerTypeId;
            CustomerDemographicLookupText = customerDemographicLookupText;
            CustomerLookupText = customerLookupText;
        }

        public CustomerCustomerDemoViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public CustomerCustomerDemoViewModel(IZDTOBase<CustomerCustomerDemoDTO, CustomerCustomerDemo> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<CustomerCustomerDemoViewModel, CustomerCustomerDemoDTO> GetDTOSelector()
        {
            return x => new CustomerCustomerDemoDTO
            {
                CustomerId = x.CustomerId,
                CustomerTypeId = x.CustomerTypeId
            };
        }

        public override Func<CustomerCustomerDemoDTO, CustomerCustomerDemoViewModel> GetViewSelector()
        {
            return x => new CustomerCustomerDemoViewModel
            {
                CustomerId = x.CustomerId,
                CustomerTypeId = x.CustomerTypeId,
                CustomerDemographicLookupText = x.CustomerDemographicLookupText,
                CustomerLookupText = x.CustomerLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                CustomerCustomerDemoDTO dto = new CustomerCustomerDemoDTO(data);
                CustomerCustomerDemoViewModel view = (new List<CustomerCustomerDemoDTO> { (CustomerCustomerDemoDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<CustomerCustomerDemoDTO, CustomerCustomerDemo> dto)
        {
            if (dto != null)
            {
                CustomerCustomerDemoViewModel view = (new List<CustomerCustomerDemoDTO> { (CustomerCustomerDemoDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<CustomerCustomerDemoDTO, CustomerCustomerDemo> ToDTO()
        {
            return (new List<CustomerCustomerDemoViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
