using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Categories
{
	public class Pick
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppUserCategoryDto AppUserCategory { get; set; }
        }

		public class CommandValidator : AbstractValidator<AppUserCategoryDto>
		{
			public CommandValidator()
			{
                RuleFor(x => x.MentorId).NotEmpty();
                RuleFor(x => x.CategoryId).NotEmpty();
            }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var appUserCategory = new AppUserCategory
                {
                    AppUserId=request.AppUserCategory.MentorId,
                    CategoryId=request.AppUserCategory.CategoryId
                };

                if (!_context.AppUserCategories.Any(x => x.AppUserId == appUserCategory.AppUserId && x.CategoryId == appUserCategory.CategoryId))
                {
                    _context.AppUserCategories.Add(appUserCategory);

                    await _context.SaveChangesAsync();

                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.Failure("Već ste izabrali ovu kategoriju");
            }
        }
    }
}