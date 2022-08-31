using FluentValidation.Results;
using SalesCatalog.Domain.Validation;
using System;

namespace SalesCatalog.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

            IsValid();
        }

        private Product() { }

        internal Product Update(string name, string description, decimal price, int stock, string image, Guid categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;

            IsValid();

            return this;
        }

        internal bool IsValid()
        {
            var errors = new ProductValidation().Validate(this).Errors;
            State = new ValidationResult(errors);
            return State.IsValid;
        }
    }
}
