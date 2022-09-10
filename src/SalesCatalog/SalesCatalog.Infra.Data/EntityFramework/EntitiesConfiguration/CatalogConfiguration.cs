using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Infra.Data.EntityFramework.EntitiesConfiguration
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("TbCatalog");
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Value).HasPrecision(18, 2);
            builder.Property(p => p.Active).IsRequired();
            builder.Property(p => p.RegisterDate).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.QtyInStock).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasPrincipalKey(e => e.Id);
            builder.Ignore(t => t.State);
        }
    }
}
