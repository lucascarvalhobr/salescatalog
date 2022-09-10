using SalesCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Domain.Interfaces
{
    public interface ICatalogRepository : IRepository<Catalog>
    {
        Task<IEnumerable<Catalog>> GetProductsAsync();
        Task<Catalog> GetProductCategoryAsync(Guid guid);
        Task<Catalog> GetByIdAsync(Guid id);
        Task<Catalog> CreateAsync(Catalog product);
        Catalog Update(Catalog product);
        void Remove(Catalog product);
    }
}
