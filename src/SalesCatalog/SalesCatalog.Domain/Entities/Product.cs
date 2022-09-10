using FluentValidation.Results;
using SalesCatalog.Domain.Validation;
using System;

namespace SalesCatalog.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public int QtyInStock { get; set; }

        public string Image { get; set; }

        public bool Active { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
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

        Product() { }

        public Product Update(string name, string description, decimal price, int stock, string image, Guid categoryId)
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
