using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Create
    {
        public class Command : IRequest
        {
            public CreateCategoryDto Category { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Category).SetValidator(new CategoriesValidator());
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var category = new Category
                {
                    Id=request.Category.Id,
                    Name=request.Category.Name
                };

                _context.Categories.Add(category);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}