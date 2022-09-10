using AutoMapper;
using SalesCatalog.Application.DTOs;
using SalesCatalog.Application.Products.Commands;

namespace SalesCatalog.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
            CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();
        }
    }
}
