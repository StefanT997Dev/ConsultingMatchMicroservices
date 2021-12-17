using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Validation;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Repositories.Mentors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
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

        public class Handler : GenericHandler<Category> ,IRequestHandler<Command,Result<Unit>>
        {
			public Handler(ICategoriesRepository categoriesRepository) : base(categoriesRepository)
            {
				
			}

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(await repository.AddAsync(request.Category))
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Failed to add a new category");
            }
        }
    }
}