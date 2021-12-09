using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public ReviewDto Review { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
			private readonly IMapper _mapper;
			private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(IMapper mapper, DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
				_mapper = mapper;
				_context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var client = await _context.Users
                    .Where(c => c.UserName == _userAccessor.GetUsername())
                    .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                var review = new Review
                {
                    StarRating = request.Review.StarRating,
                    Comment = request.Review.Comment,
                    MentorId = request.Id,
                    ClientId= client.Id
                };

                _context.Reviews.Add(review);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}