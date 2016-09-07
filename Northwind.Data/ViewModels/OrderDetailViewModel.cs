using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Data.Resources;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class OrderDetailViewModel : ZViewBase<OrderDetailViewModel, OrderDetailDTO, OrderDetail>
    {
        #region Properties
        
        [Display(Name = "PropertyOrderId", ResourceType = typeof(OrderDetailResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        //[Column(Order=1)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int OrderId { get; set; }
        
        [Display(Name = "PropertyProductId", ResourceType = typeof(OrderDetailResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        //[Key]
        //[Column(Order=2)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual int ProductId { get; set; }
        
        [Display(Name = "PropertyUnitPrice", ResourceType = typeof(OrderDetailResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        [Range(0.01, Double.MaxValue)]
        [Required]
        public virtual decimal UnitPrice { get; set; }
        
        [Display(Name = "PropertyQuantity", ResourceType = typeof(OrderDetailResources))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Range(1, Int32.MaxValue)]
        [Required]
        public virtual short Quantity { get; set; }
        
        [Display(Name = "PropertyDiscount", ResourceType = typeof(OrderDetailResources))]
        [DisplayFormat(DataFormatString = "{0:f2}", ApplyFormatInEditMode = true)]
        [Range(0.01, Double.MaxValue)]
        [Required]
        public virtual float Discount { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string OrderLookupText { get; set; } // OrderId

        public virtual string ProductLookupText { get; set; } // ProductId
    
        #endregion Associations FK

        #region Properties ZViewBase

        public override string LookupText { get; set; }

        #endregion Properties ZViewBase

        #region Methods
        
        public OrderDetailViewModel()
        {
            OrderId = 1;
            ProductId = 1;
        }
        
        public OrderDetailViewModel(
            int orderId,
            int productId,
            decimal unitPrice,
            short quantity,
            float discount,
            string orderLookupText = null,
            string productLookupText = null
        )
            : this()
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
            OrderLookupText = orderLookupText;
            ProductLookupText = productLookupText;
        }

        public OrderDetailViewModel(IZDataBase data)
        {
            FromData(data);
        }

        public OrderDetailViewModel(IZDTOBase<OrderDetailDTO, OrderDetail> dto)
        {
            FromDTO(dto);
        }

        #endregion Methods

        #region Methods ZViewBase

        public override Func<OrderDetailViewModel, OrderDetailDTO> GetDTOSelector()
        {
            return x => new OrderDetailDTO
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Discount = x.Discount,
                OrderLookupText = x.OrderLookupText,
                ProductLookupText = x.ProductLookupText,
                LookupText = x.LookupText
            };
        }

        public override Func<OrderDetailDTO, OrderDetailViewModel> GetViewSelector()
        {
            return x => new OrderDetailViewModel
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Discount = x.Discount,
                OrderLookupText = x.OrderLookupText,
                ProductLookupText = x.ProductLookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                OrderDetailDTO dto = new OrderDetailDTO(data);
                OrderDetailViewModel view = (new List<OrderDetailDTO> { (OrderDetailDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);            
            }
        }

        public override void FromDTO(IZDTOBase<OrderDetailDTO, OrderDetail> dto)
        {
            if (dto != null)
            {
                OrderDetailViewModel view = (new List<OrderDetailDTO> { (OrderDetailDTO)dto })
                    .Select(GetViewSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(view, this);
            }
        }

        public override IZDataBase ToData()
        {
            return ToDTO().ToData();
        }
        
        public override IZDTOBase<OrderDetailDTO, OrderDetail> ToDTO()
        {
            return (new List<OrderDetailViewModel> { this })
                .Select(GetDTOSelector())
                .SingleOrDefault();   
        }
        
        #endregion Methods ZViewBase
    }
}
