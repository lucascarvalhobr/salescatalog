using FluentValidation.Results;
using System;

namespace SalesCatalog.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public DateTime RegisterDate { get; set; }

        public ValidationResult State { get; set; }
    }
}
