using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Northwind.Data;

namespace Northwind.Persistence
{
    public class EmployeeTerritoryConfiguration : EntityTypeConfiguration<EmployeeTerritory>
    {
        public EmployeeTerritoryConfiguration()
        {
            #region Class
            
            this.ToTable("EmployeeTerritories");            

            this.HasKey(x => new { x.EmployeeId , x.TerritoryId });

            #endregion Class

            #region Properties
        
            this.Property(x => x.EmployeeId)
                .HasColumnName("EmployeeID")
                .HasColumnOrder(1)
                .HasColumnType("int")
                .IsRequired();
        
            this.Property(x => x.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            #endregion Properties

            #region Associations (FK)
            
            this.HasRequired(x => x.Employee)
                .WithMany(x => x.EmployeeTerritories)
                .HasForeignKey(x => x.EmployeeId);
            
            this.HasRequired(x => x.Territory)
                .WithMany(x => x.EmployeeTerritories)
                .HasForeignKey(x => x.TerritoryId);
		
            #endregion Associations (FK)
        }
    }
}
