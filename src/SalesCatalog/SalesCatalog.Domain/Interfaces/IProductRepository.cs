using SalesCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Product product);
        Task<Category> UpdateAsync(Product product);
        Task<Category> RemoveAsync(Product product);
    }
}
