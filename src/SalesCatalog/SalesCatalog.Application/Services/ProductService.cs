using AutoMapper;
using MediatR;
using SalesCatalog.Application.DTOs;
using SalesCatalog.Application.Interfaces;
using SalesCatalog.Application.Products.Commands;
using SalesCatalog.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var productQuery = new GetProductByIdQuery(id);

            var product = await _mediator.Send(productQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            var products = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task Remove(Guid id)
        {
            var productRemoveCommand = _mapper.Map<ProductRemoveCommand>(id);
            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
