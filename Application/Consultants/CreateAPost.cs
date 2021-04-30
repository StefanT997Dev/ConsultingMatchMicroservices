using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Consultants
{
    public class CreateAPost
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
            public Post Post { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var consultant = await _context.Users.FindAsync(request.Id);

                var post = new Post{
                    Id=request.Post.Id,
                    Title=request.Post.Title,
                    Description=request.Post.Description,
                    Picture=request.Post.Picture,
                    Video=request.Post.Video,
                    Consultant=consultant
                };

                _context.Posts.Add(post);

                var result = await _context.SaveChangesAsync()>0;

                if(!result) return Result<Unit>.Failure("Failed to create post");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}