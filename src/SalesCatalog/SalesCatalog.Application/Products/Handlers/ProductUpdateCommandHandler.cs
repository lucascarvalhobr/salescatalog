using MediatR;
using SalesCatalog.Application.Products.Commands;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException("Error could not be found");
            }

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            return _productRepository.Update(product);
        }
    }
}
