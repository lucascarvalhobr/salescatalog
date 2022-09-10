using SalesCatalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<CategoryDTO> GetCategoryById(Guid id);

        Task Add(CategoryDTO categoryDto);

        Task Update(CategoryDTO categoryDto);

        Task Remove(Guid id);
    }
}
