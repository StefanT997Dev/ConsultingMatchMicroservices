using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Reviews
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public Review Review { get; set; }
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
                var consultant = await _context.Users.FindAsync(request.Id);

                var review = new Review{
                    Id=request.Review.Id,
                    StarRating=request.Review.StarRating,
                    Comment=request.Review.Comment,
                    Consultant=consultant
                };

                _context.Reviews.Add(review);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}