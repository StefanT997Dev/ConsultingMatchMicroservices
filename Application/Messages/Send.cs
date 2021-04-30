using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Messages
{
    public class Send
    {
        public class Command : IRequest
        {
            public string ConsultantId { get; set; }
            public Message Message { get; set; }
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
                var consultant = await _context.Users.FindAsync(request.ConsultantId);

                var message = new Message{
                    Id=request.Message.Id,
                    Content=request.Message.Content,
                    Consultant=consultant
                };

                _context.Messages.Add(message);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}