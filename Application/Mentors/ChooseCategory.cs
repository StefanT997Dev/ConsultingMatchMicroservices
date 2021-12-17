using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.AppUserCategories;
using Application.Interfaces.Repositories.Categories;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mentors
{
	public class ChooseCategory
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppUserCategoryDto AppUserCategory { get; set; }
        }

		public class CommandValidator : AbstractValidator<AppUserCategoryDto>
		{
			public CommandValidator()
			{
                RuleFor(x => x.AppUserId).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
            }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
        {
			private readonly DataContext _context;
			private readonly IAppUserCategoriesRepository _appUserCategoriesRepository;

			public Handler(DataContext context, IAppUserCategoriesRepository appUserCategoriesRepository)
			{
				_context = context;
				_appUserCategoriesRepository = appUserCategoriesRepository;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.AppUserCategories.AnyAsync(x => x.AppUserId == request.AppUserCategory.AppUserId
                    && x.CategoryId == request.AppUserCategory.CategoryId))
                {
                    return Result<Unit>.Failure("Već ste izabrali ovu kategoriju");
                }
                if (await _appUserCategoriesRepository.AddAsync(request.AppUserCategory))
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Nismo uspeli da dodamo kategoriju vašoj listi kategorija");
            }
        }
    }
}