using ManufacturingInventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManufacturingInventory.Infraestructure.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.ProductionType)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
