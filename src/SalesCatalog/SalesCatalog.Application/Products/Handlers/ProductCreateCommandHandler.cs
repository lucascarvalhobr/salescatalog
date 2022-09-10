using MediatR;
using SalesCatalog.Application.Products.Commands;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product == null)
            {
                throw new ApplicationException("Error creating entity.");
            }

            product.CategoryId = request.CategoryId;

            return await _productRepository.CreateAsync(product);
        }
    }
}
