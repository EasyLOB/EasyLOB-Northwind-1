using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class ShipperViewModel : ZViewBase<ShipperViewModel, ShipperDTO, Shipper>
    {
        #region Properties
        
        [Display(Name = "PropertyShipperId", ResourceType = typeof(ShipperResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int ShipperId { get; set; }
        
        [Display(Name = "PropertyCompanyName", ResourceType = typeof(ShipperResources))]
        [Required]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }
        
        [Display(Name = "PropertyPhone", ResourceType = typeof(ShipperResources))]
        [StringLength(24)]
        public virtual string Phone { get; set; }

        #endregion Properties

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public ShipperViewModel()
        {
            ShipperId = 1;
        }
        
        public ShipperViewModel(
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

        public ShipperViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public ShipperViewModel(IZDTOBase<ShipperDTO, Shipper> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<ShipperViewModel, ShipperDTO> GetDTOSelector()
        {
            return x => new ShipperDTO
            {
                ShipperId = x.ShipperId,
                CompanyName = x.CompanyName,
                Phone = x.Phone,
                LookupText = x.LookupText
            };
        }

        public override Func<ShipperDTO, ShipperViewModel> GetViewSelector()
        {
            return x => new ShipperViewModel
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
                ShipperDTO dto = new ShipperDTO(data);
                ShipperViewModel view = (new List<ShipperDTO> { (ShipperDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<ShipperDTO, Shipper> dto)
        {
            if (dto != null)
            {
                ShipperViewModel view = (new List<ShipperDTO> { (ShipperDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<ShipperDTO, Shipper> ToDTO()
        {
            return (new List<ShipperViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
