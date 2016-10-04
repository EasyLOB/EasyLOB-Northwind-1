using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class OrderDetailDTO : ZDTOBase<OrderDetailDTO, OrderDetail>
    {
        #region Properties
               
        public virtual int OrderId { get; set; }
               
        public virtual int ProductId { get; set; }
               
        public virtual decimal UnitPrice { get; set; }
               
        public virtual short Quantity { get; set; }
               
        public virtual float Discount { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string OrderLookupText { get; set; } // OrderId

        public virtual string ProductLookupText { get; set; } // ProductId
    
        #endregion Associations FK

        #region Methods
        
        public OrderDetailDTO()
        {
            OrderId = LibraryDefaults.Default_Int32;
            ProductId = LibraryDefaults.Default_Int32;
            UnitPrice = LibraryDefaults.Default_Decimal;
            Quantity = LibraryDefaults.Default_Int16;
            Discount = LibraryDefaults.Default_Single;
        }
        
        public OrderDetailDTO(
            int orderId,
            int productId,
            decimal unitPrice,
            short quantity,
            float discount,
            string orderLookupText = null,
            string productLookupText = null
        )
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
            OrderLookupText = orderLookupText;
            ProductLookupText = productLookupText;
        }

        public OrderDetailDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<OrderDetailDTO, OrderDetail> GetDataSelector()
        {
            return x => new OrderDetail
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Discount = x.Discount
            };
        }

        public override Func<OrderDetail, OrderDetailDTO> GetDTOSelector()
        {
            return x => new OrderDetailDTO
            {
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                Quantity = x.Quantity,
                Discount = x.Discount,
                OrderLookupText = x.Order == null ? "" : x.Order.LookupText,
                ProductLookupText = x.Product == null ? "" : x.Product.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                OrderDetailDTO dto = (new List<OrderDetail> { (OrderDetail)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<OrderDetailDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
