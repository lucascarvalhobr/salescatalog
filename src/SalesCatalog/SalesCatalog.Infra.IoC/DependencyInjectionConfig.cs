using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SalesCatalog.Application.Interfaces;
using SalesCatalog.Application.Mappings;
using SalesCatalog.Application.Services;
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
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<ICategoryService, CategoryService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDTOMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
