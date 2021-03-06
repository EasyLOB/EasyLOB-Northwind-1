using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Northwind.Data;

namespace Northwind.Persistence
{
    public class CustomerDemographicConfiguration : EntityTypeConfiguration<CustomerDemographic>
    {
        public CustomerDemographicConfiguration()
        {
            #region Class
            
            this.ToTable("CustomerDemographics");            

            this.HasKey(x => x.CustomerTypeId);

            #endregion Class

            #region Properties
        
            this.Property(x => x.CustomerTypeId)
                .HasColumnName("CustomerTypeID")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
        
            this.Property(x => x.CustomerDesc)
                .HasColumnName("CustomerDesc")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            #endregion Properties
        }
    }
}
