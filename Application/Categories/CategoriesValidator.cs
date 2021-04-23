using Domain;
using FluentValidation;

namespace Application.Categories
{
    public class CategoriesValidator : AbstractValidator<Category>
    {
        public CategoriesValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}