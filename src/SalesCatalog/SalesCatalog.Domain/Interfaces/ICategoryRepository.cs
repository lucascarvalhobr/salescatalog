using SalesCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
