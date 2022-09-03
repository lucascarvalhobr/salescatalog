using SalesCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductCategoryAsync(Guid guid);
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product product);
        Product Update(Product product);
        void Remove(Product product);
    }
}
