using FluentAssertions;
using SalesCatalog.Domain.Entities;
using Xunit;

namespace SalesCatalog.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product with Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            var category = new Catalog(name: "My product", description: "Description", price: 10, stock: 100, image: "image path");
            category.State.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Create Product with Invalid State")]
        public void CreateCategory_WithInValidParameters_ResultObjectInvalidState()
        {
            var category = new Catalog(name: string.Empty, description: null, price: 0, stock: -1, image: string.Empty);

            category.State.IsValid.Should().BeFalse();
            category.State.Errors.Should().HaveCount(4);
        }
    }
}
