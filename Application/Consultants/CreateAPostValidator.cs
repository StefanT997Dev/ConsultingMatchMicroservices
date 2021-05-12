using Domain;
using FluentValidation;

namespace Application.Consultants
{
    public class CreateAPostValidator : AbstractValidator<Post>
    {
        public CreateAPostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p=>p.Description).NotEmpty();
        }
    }
}