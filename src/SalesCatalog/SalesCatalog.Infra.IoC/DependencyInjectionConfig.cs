using Microsoft.Extensions.DependencyInjection;
using SalesCatalog.Domain.Interfaces;
using SalesCatalog.Infra.Data.EntityFramework.Context;
using SalesCatalog.Infra.Data.EntityFramework.Repositories;
using SalesCatalog.Infra.DataEntityFramework.Repositories;

namespace SalesCatalog.Infra.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
