using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Infra.Data.EntityFramework.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasPrincipalKey(e => e.Id);

            builder.HasData
                (
                    new Category("Eletronics"),
                    new Category("Beauty"),
                    new Category("Fashion"),
                    new Category("Video Games"),
                    new Category("Toys"),
                    new Category("Books"),
                    new Category("Home")
                );
        }
    }
}
