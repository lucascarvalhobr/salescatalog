using SalesCatalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetProductById(Guid id);

        Task Add(ProductDTO productDto);

        Task Update(ProductDTO productDto);

        Task Remove(Guid id);
    }
}
