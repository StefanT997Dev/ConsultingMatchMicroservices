using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.Reviews;
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
        public class Command : IRequest <Result<Unit>>
        {
            public string Id { get; set; }
            public ReviewDto Review { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
			private readonly IMapper _mapper;
			private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
			private readonly IReviewsRepository _reviewsRepository;

			public Handler(
                IMapper mapper,
                DataContext context, 
                IUserAccessor userAccessor,
                IReviewsRepository reviewsRepository)
            {
                _userAccessor = userAccessor;
				_reviewsRepository = reviewsRepository;
				_mapper = mapper;
				_context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var client = await _context.Users
                    .Where(c => c.UserName == _userAccessor.GetUsername())
                    .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                // Ako nije njegov klijent ne moze da ostavi recenziju
                var mentorship = await _context.Mentorships.FirstOrDefaultAsync(x => x.ClientId == client.Id
                    && x.MentorId == request.Id);

                if (mentorship == null)
                {
                    return Result<Unit>.Failure("Ne možete ostaviti recenziju za ovog mentora jer niste njegov klijent");
                }

                var review = new Review
                {
                    StarRating = request.Review.StarRating,
                    Comment = request.Review.Comment,
                    MentorId = request.Id,
                    ClientId= client.Id
                };

                if (await _context.Reviews.AnyAsync(x => x.ClientId == client.Id
                    && x.MentorId == request.Id))
                {
                    return Result<Unit>.Failure("Već ste ostavili recenziju za mentora");
                }
                if (await _reviewsRepository.AddAsync(review))
                {
                    return Result<Unit>.Success(Unit.Value);
                }

                return Result<Unit>.Failure("Nismo uspeli da zapamtimo recenziju");
            }
        }
    }
}