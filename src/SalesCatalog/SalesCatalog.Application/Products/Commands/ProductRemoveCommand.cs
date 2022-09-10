using MediatR;
using SalesCatalog.Domain.Entities;
using System;

namespace SalesCatalog.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public Guid Id { get; set; }

        public ProductRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
