using AutoMapper;
using SalesCatalog.Application.DTOs;
using SalesCatalog.Application.Interfaces;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository catalogRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        public async Task Add(CatalogDTO catalogDto)
        {
            var catalog = _mapper.Map<Catalog>(catalogDto);
            await _catalogRepository.CreateAsync(catalog);
            await Commit();
        }

        public async Task<CatalogDTO> GetCatalogById(Guid id)
        {
            var catalog = await _catalogRepository.GetByIdAsync(id);
            return _mapper.Map<CatalogDTO>(catalog);
        }

        public async Task<IEnumerable<CatalogDTO>> GetCatalogs()
        {
            var catalogs = await _catalogRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<CatalogDTO>>(catalogs);
        }

        public async Task Remove(Guid id)
        {
            var catalog = await _catalogRepository.GetByIdAsync(id);
            _catalogRepository.Remove(catalog);
            await Commit();
        }

        public async Task Update(CatalogDTO catalogDto)
        {
            var catalog = _mapper.Map<Catalog>(catalogDto);
            _catalogRepository.Update(catalog);
            await Commit();
        }

        private async Task Commit()
        {
            await _catalogRepository.UnitOfWork.Commit();
        }
    }
}
