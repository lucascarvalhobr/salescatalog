using Microsoft.EntityFrameworkCore;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using System.Threading.Tasks;

namespace SalesCatalog.Infra.Data.EntityFramework.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Catalog> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            bool success = await base.SaveChangesAsync() > 0;

            return success;
        }
    }
}
