using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Roles
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string RoleName { get; set; }
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
                var role = new Role
                {
                    Name=request.RoleName   
                };

                _context.Roles.Add(role);

                var result = await _context.SaveChangesAsync() > 0;

                if(result)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                return Result<Unit>.Failure("Nismo uspeli da kreiramo novu ulogu");
            }
        }
    }
}