using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Northwind.Data;

namespace Northwind.Persistence
{
    public class RegionConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionConfiguration()
        {
            #region Class
            
            this.ToTable("Region");            

            this.HasKey(x => x.RegionId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.RegionId)
                .HasColumnName("RegionID")
                .HasColumnType("int")
                .IsRequired();
        
            this.Property(x => x.RegionDescription)
                .HasColumnName("RegionDescription")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            #endregion Properties
        }
    }
}
