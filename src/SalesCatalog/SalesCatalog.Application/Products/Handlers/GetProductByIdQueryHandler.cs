using MediatR;
using SalesCatalog.Application.Products.Queries;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SalesCatalog.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
