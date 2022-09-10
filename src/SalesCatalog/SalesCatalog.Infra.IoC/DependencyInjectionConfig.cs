using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SalesCatalog.Application.Interfaces;
using SalesCatalog.Application.Mappings;
using SalesCatalog.Application.Services;
using SalesCatalog.Domain.Interfaces;
using SalesCatalog.Infra.Data.EntityFramework.Context;
using SalesCatalog.Infra.Data.EntityFramework.Repositories;
using SalesCatalog.Infra.DataEntityFramework.Repositories;
using System;

namespace SalesCatalog.Infra.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

            var mediatrHandlers = AppDomain.CurrentDomain.Load("SalesCatalog.Application");
            services.AddMediatR(mediatrHandlers);
        }
    }
}
