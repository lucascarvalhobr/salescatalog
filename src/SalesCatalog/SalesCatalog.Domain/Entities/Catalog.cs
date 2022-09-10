using FluentValidation.Results;
using SalesCatalog.Domain.Validation;
using System;

namespace SalesCatalog.Domain.Entities
{
    public sealed class Catalog : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public int QtyInStock { get; private set; }

        public string Image { get; private set; }

        public bool Active { get; set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public Catalog(string name, string description, decimal price, int stock, string image)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Value = price;
            QtyInStock = stock;
            Image = image;
            RegisterDate = DateTime.Now;

            IsValid();
        }

        private Catalog() { }

        internal Catalog Update(string name, string description, decimal price, int stock, string image, Guid categoryId)
        {
            Name = name;
            Description = description;
            Value = price;
            QtyInStock = stock;
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
