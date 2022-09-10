using SalesCatalog.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogDTO>> GetCatalogs();

        Task<CatalogDTO> GetCatalogById(Guid id);

        Task Add(CatalogDTO catalogDto);

        Task Update(CatalogDTO catalogDto);

        Task Remove(Guid id);
    }
}
