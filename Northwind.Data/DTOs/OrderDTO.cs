using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class OrderDTO : ZDTOBase<OrderDTO, Order>
    {
        #region Properties
               
        public virtual int OrderId { get; set; }
               
        public virtual string CustomerId { get; set; }
               
        public virtual int? EmployeeId { get; set; }
               
        public virtual DateTime? OrderDate { get; set; }
               
        public virtual DateTime? RequiredDate { get; set; }
               
        public virtual DateTime? ShippedDate { get; set; }
               
        public virtual int? ShipVia { get; set; }
               
        public virtual decimal? Freight { get; set; }
               
        public virtual string ShipName { get; set; }
               
        public virtual string ShipAddress { get; set; }
               
        public virtual string ShipCity { get; set; }
               
        public virtual string ShipRegion { get; set; }
               
        public virtual string ShipPostalCode { get; set; }
               
        public virtual string ShipCountry { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string CustomerLookupText { get; set; } // CustomerId

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string ShipperLookupText { get; set; } // ShipVia
    
        #endregion Associations FK

        #region Properties ZDTOBase

        public override string LookupText { get; set; }

        #endregion Properties ZDTOBase

        #region Methods
        
        public OrderDTO()
        {
        }
        
        public OrderDTO(
            int orderId,
            string customerId = null,
            int? employeeId = null,
            DateTime? orderDate = null,
            DateTime? requiredDate = null,
            DateTime? shippedDate = null,
            int? shipVia = null,
            decimal? freight = null,
            string shipName = null,
            string shipAddress = null,
            string shipCity = null,
            string shipRegion = null,
            string shipPostalCode = null,
            string shipCountry = null,
            string customerLookupText = null,
            string employeeLookupText = null,
            string shipperLookupText = null
        )
        {
            OrderId = orderId;
            CustomerId = customerId;
            EmployeeId = employeeId;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipVia = shipVia;
            Freight = freight;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipRegion = shipRegion;
            ShipPostalCode = shipPostalCode;
            ShipCountry = shipCountry;
            CustomerLookupText = customerLookupText;
            EmployeeLookupText = employeeLookupText;
            ShipperLookupText = shipperLookupText;
        }

        public OrderDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<OrderDTO, Order> GetDataSelector()
        {
            return x => new Order
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
                ShipVia = x.ShipVia,
                Freight = x.Freight,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipRegion = x.ShipRegion,
                ShipPostalCode = x.ShipPostalCode,
                ShipCountry = x.ShipCountry
            };
        }

        public override Func<Order, OrderDTO> GetDTOSelector()
        {
            return x => new OrderDTO
            {
                OrderId = x.OrderId,
                CustomerId = x.CustomerId,
                EmployeeId = x.EmployeeId,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
                ShipVia = x.ShipVia,
                Freight = x.Freight,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipRegion = x.ShipRegion,
                ShipPostalCode = x.ShipPostalCode,
                ShipCountry = x.ShipCountry,
                CustomerLookupText = x.Customer == null ? "" : x.Customer.LookupText,
                EmployeeLookupText = x.Employee == null ? "" : x.Employee.LookupText,
                ShipperLookupText = x.Shipper == null ? "" : x.Shipper.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                OrderDTO dto = (new List<Order> { (Order)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<OrderDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
