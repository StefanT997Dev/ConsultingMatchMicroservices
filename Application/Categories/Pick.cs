using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Categories
{
    public class Pick
    {
        public class Command : IRequest
        {
            public AppUserCategory AppUserCategory { get; set; }
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
                _context.AppUserCategories.Add(request.AppUserCategory);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}