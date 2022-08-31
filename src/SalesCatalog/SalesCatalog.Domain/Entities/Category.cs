using FluentValidation.Results;
using SalesCatalog.Domain.Validation;
using System;
using System.Collections.Generic;

namespace SalesCatalog.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            IsValid();
        }

        private Category() { }

        internal Category Update(string name)
        {
            Name = name;

            IsValid();

            return this;
        }

        internal bool IsValid()
        {
            var errors = new CategoryValidation().Validate(this).Errors;
            State = new ValidationResult(errors);
            return State.IsValid;
        }
    }
}
