using FluentValidation;
using SalesCatalog.Domain.Entities;

namespace SalesCatalog.Domain.Validation
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required");
        }
    }
}
