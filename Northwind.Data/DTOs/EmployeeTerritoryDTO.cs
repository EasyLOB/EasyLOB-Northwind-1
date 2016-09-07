using System;
using System.Collections.Generic;
using System.Linq;
using EasyLOB.Data;
using EasyLOB.Library;

namespace Northwind.Data
{
    public partial class EmployeeTerritoryDTO : ZDTOBase<EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string TerritoryId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string TerritoryLookupText { get; set; } // TerritoryId
    
        #endregion Associations FK

        #region Properties ZDTOBase

        public override string LookupText { get; set; }

        #endregion Properties ZDTOBase

        #region Methods
        
        public EmployeeTerritoryDTO()
        {
        }
        
        public EmployeeTerritoryDTO(
            int employeeId,
            string territoryId,
            string employeeLookupText = null,
            string territoryLookupText = null
        )
        {
            EmployeeId = employeeId;
            TerritoryId = territoryId;
            EmployeeLookupText = employeeLookupText;
            TerritoryLookupText = territoryLookupText;
        }

        public EmployeeTerritoryDTO(IZDataBase data)
        {
            FromData(data);
        }
        
        #endregion Methods

        #region Methods ZDTOBase

        public override Func<EmployeeTerritoryDTO, EmployeeTerritory> GetDataSelector()
        {
            return x => new EmployeeTerritory
            {
                EmployeeId = x.EmployeeId,
                TerritoryId = x.TerritoryId
            };
        }

        public override Func<EmployeeTerritory, EmployeeTerritoryDTO> GetDTOSelector()
        {
            return x => new EmployeeTerritoryDTO
            {
                EmployeeId = x.EmployeeId,
                TerritoryId = x.TerritoryId,
                EmployeeLookupText = x.Employee == null ? "" : x.Employee.LookupText,
                TerritoryLookupText = x.Territory == null ? "" : x.Territory.LookupText,
                LookupText = x.LookupText
            };
        }

        public override void FromData(IZDataBase data)
        {
            if (data != null)
            {
                EmployeeTerritoryDTO dto = (new List<EmployeeTerritory> { (EmployeeTerritory)data })
                    .Select(GetDTOSelector())
                    .SingleOrDefault();
                LibraryHelper.Clone(dto, this);
            }
        }

        public override IZDataBase ToData()
        {
            return (new List<EmployeeTerritoryDTO> { this })
                .Select(GetDataSelector())
                .SingleOrDefault();
        }

        #endregion Methods ZDTOBase
    }
}
