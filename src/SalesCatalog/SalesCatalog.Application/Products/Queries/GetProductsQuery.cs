using MediatR;
using SalesCatalog.Domain.Entities;
using System.Collections.Generic;

namespace SalesCatalog.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
