using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Infra.Data.EntityFramework.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("TbCategory");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Ignore(t => t.State);

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