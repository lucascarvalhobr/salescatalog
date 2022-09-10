using MediatR;
using SalesCatalog.Domain.Entities;
using System;

namespace SalesCatalog.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
