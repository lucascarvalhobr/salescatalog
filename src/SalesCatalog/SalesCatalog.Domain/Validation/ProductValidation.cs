using FluentValidation;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Domain.Validation
{
    public class ProductValidation : AbstractValidator<Catalog>
    {
        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Product name is required ");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Product description is required");

            RuleFor(c => c.Image)
                .Length(0, 250)
                .WithMessage("Product image must be until 250 characters");

            RuleFor(c => c.Value)
                .GreaterThan(0)
                .WithMessage("Product price is required and must be greater than 0");

            RuleFor(c => c.QtyInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product stock must be greater or equal to 0");
        }
    }
}
