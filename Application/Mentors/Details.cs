using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Mentors
{
    public class Details
    {
        public class Query : IRequest<Result<MentorDisplayDto>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MentorDisplayDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<MentorDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                var listOfCategoryNames = await Common.GetCategoriesForUser(_context, user);

                var listOfReviewsDtoForMentor = await Common.GetUserReviews(_context, _mapper, user.Id);

                var result = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForMentor);

                var MentorDisplayDto = new MentorDisplayDto
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Image = user.ProfilePicture,
                    Bio = user.Bio,
                    NumberOfReviews = listOfReviewsDtoForMentor.Count,
                    AverageStarReview = result.Item2,
                    Reviews = listOfReviewsDtoForMentor,
                    TotalStarRating = result.Item1
                    // Categories = listOfCategoryNames
                };

                return Result<MentorDisplayDto>.Success(MentorDisplayDto);
            }
        }
    }
}