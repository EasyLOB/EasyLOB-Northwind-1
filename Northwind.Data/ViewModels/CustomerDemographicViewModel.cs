using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class CustomerDemographicViewModel : ZViewBase<CustomerDemographicViewModel, CustomerDemographicDTO, CustomerDemographic>
    {
        #region Properties
        
        [Display(Name = "PropertyCustomerTypeId", ResourceType = typeof(CustomerDemographicResources))]
        //[Key]
        [Required]
        [StringLength(10)]
        public virtual string CustomerTypeId { get; set; }
        
        [Display(Name = "PropertyCustomerDesc", ResourceType = typeof(CustomerDemographicResources))]
        [StringLength(1024)]
        public virtual string CustomerDesc { get; set; }

        #endregion Properties

        #region Methods
        
        public CustomerDemographicViewModel()
        {
            CustomerTypeId = LibraryDefaults.Default_String;
            CustomerDesc = null;
        }
        
        public CustomerDemographicViewModel(
            string customerTypeId,
            string customerDesc = null
        )
            : this()
        {
            CustomerTypeId = customerTypeId;
            CustomerDesc = customerDesc;
        }

        public CustomerDemographicViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public CustomerDemographicViewModel(IZDTOBase<CustomerDemographicDTO, CustomerDemographic> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<CustomerDemographicViewModel, CustomerDemographicDTO> GetDTOSelector()
        {
            return x => new CustomerDemographicDTO
            {
                CustomerTypeId = x.CustomerTypeId,
                CustomerDesc = x.CustomerDesc
            };
        }

        public override Func<CustomerDemographicDTO, CustomerDemographicViewModel> GetViewSelector()
        {
            return x => new CustomerDemographicViewModel
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
                CustomerDemographicDTO dto = new CustomerDemographicDTO(data);
                CustomerDemographicViewModel view = (new List<CustomerDemographicDTO> { (CustomerDemographicDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<CustomerDemographicDTO, CustomerDemographic> dto)
        {
            if (dto != null)
            {
                CustomerDemographicViewModel view = (new List<CustomerDemographicDTO> { (CustomerDemographicDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<CustomerDemographicDTO, CustomerDemographic> ToDTO()
        {
            return (new List<CustomerDemographicViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
