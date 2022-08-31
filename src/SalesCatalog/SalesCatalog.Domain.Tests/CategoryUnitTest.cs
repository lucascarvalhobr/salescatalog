using FluentAssertions;
using SalesCatalog.Domain.Entities;
using Xunit;

namespace SalesCatalog.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category with Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            var category = new Category("Category Name");
            category.State.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Create Category with Invalid State")]
        public void CreateCategory_WithInValidParameters_ResultObjectInvalidState()
        {
            var category = new Category(null);
            category.State.IsValid.Should().BeFalse();

            category = new Category(string.Empty);
            category.State.IsValid.Should().BeFalse();
        }
    }
}
