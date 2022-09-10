using AutoMapper;
using SalesCatalog.Application.DTOs;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
