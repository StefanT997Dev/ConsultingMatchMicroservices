using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;

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
			private readonly IMentorsRepository _mentorsRepository;
		
            public Handler(IMentorsRepository mentorsRepository)
            {
                _mentorsRepository = mentorsRepository;
			}

            public async Task<Result<MentorDisplayDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _mentorsRepository.GetAsync<MentorDisplayDto>(request.Id);

                if (user == null)
                {
                    return Result<MentorDisplayDto>.Failure("Nismo uspeli da pronađemo željenog korisnika");
                }

                user.NumberOfReviews = user.Reviews.Count;

                var result = Common.GetTotalStarRatingAndAverageStarReview(user.Reviews);

                user.TotalStarRating = result.Item1;

                user.AverageStarReview = result.Item2;

                return Result<MentorDisplayDto>.Success(user);
            }
        }
    }
}