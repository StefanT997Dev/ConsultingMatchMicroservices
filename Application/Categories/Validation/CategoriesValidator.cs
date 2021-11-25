using Application.DTOs;
using FluentValidation;

namespace Application.Categories.Validation
{
	public class CategoriesValidator : AbstractValidator<CreateCategoryDto>
    {
        public CategoriesValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}