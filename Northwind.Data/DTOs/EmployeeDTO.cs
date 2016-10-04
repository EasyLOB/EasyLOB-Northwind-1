using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class EmployeeDTO : ZDTOBase<EmployeeDTO, Employee>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string LastName { get; set; }
               
        public virtual string FirstName { get; set; }
               
        public virtual string Title { get; set; }
               
        public virtual string TitleOfCourtesy { get; set; }
               
        public virtual DateTime? BirthDate { get; set; }
               
        public virtual DateTime? HireDate { get; set; }
               
        public virtual string Address { get; set; }
               
        public virtual string City { get; set; }
               
        public virtual string Region { get; set; }
               
        public virtual string PostalCode { get; set; }
               
        public virtual string Country { get; set; }
               
        public virtual string HomePhone { get; set; }
               
        public virtual string Extension { get; set; }
               
        public virtual byte[] Photo { get; set; }
               
        public virtual string Notes { get; set; }
               
        public virtual int? ReportsTo { get; set; }
               
        public virtual string PhotoPath { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // ReportsTo
    
        #endregion Associations FK

        #region Methods
        
        public EmployeeDTO()
        {
            EmployeeId = LibraryDefaults.Default_Int32;
            LastName = LibraryDefaults.Default_String;
            FirstName = LibraryDefaults.Default_String;
            Title = null;
            TitleOfCourtesy = null;
            BirthDate = null;
            HireDate = null;
            Address = null;
            City = null;
            Region = null;
            PostalCode = null;
            Country = null;
            HomePhone = null;
            Extension = null;
            Photo = null;
            Notes = null;
            ReportsTo = null;
            PhotoPath = null;
        }
        
        public EmployeeDTO(
            int employeeId,
            string lastName,
            string firstName,
            string title = null,
            string titleOfCourtesy = null,
            DateTime? birthDate = null,
            DateTime? hireDate = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string homePhone = null,
            string extension = null,
            byte[] photo = null,
            string notes = null,
            int? reportsTo = null,
            string photoPath = null,
            string employeeLookupText = null
        )
        {
            EmployeeId = employeeId;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
            PhotoPath = photoPath;
            EmployeeLookupText = employeeLookupText;
        }

        public EmployeeDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<EmployeeDTO, Employee> GetDataSelector()
        {
            return x => new Employee
            {
                EmployeeId = x.EmployeeId,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                HomePhone = x.HomePhone,
                Extension = x.Extension,
                Photo = x.Photo,
                Notes = x.Notes,
                ReportsTo = x.ReportsTo,
                PhotoPath = x.PhotoPath
            };
        }

        public override Func<Employee, EmployeeDTO> GetDTOSelector()
        {
            return x => new EmployeeDTO
            {
                EmployeeId = x.EmployeeId,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                HomePhone = x.HomePhone,
                Extension = x.Extension,
                Photo = x.Photo,
                Notes = x.Notes,
                ReportsTo = x.ReportsTo,
                PhotoPath = x.PhotoPath,
                EmployeeLookupText = x.EmployeeReportsTo == null ? "" : x.EmployeeReportsTo.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                EmployeeDTO dto = (new List<Employee> { (Employee)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<EmployeeDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
