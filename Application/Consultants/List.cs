using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Consultants
{
    public class List
    {
        public class Query : IRequest<Result<List<ConsultantDisplayDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ConsultantDisplayDto>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<ConsultantDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.Include(u => u.Reviews).ToListAsync();
                
                var listOfConsultantDisplayDtos = new List<ConsultantDisplayDto>();

                var listOfReviewsDtoForConsultant = new List<ReviewDto>();

                foreach(var user in users)
                {
                    foreach(var review in user.Reviews)
                    {
                        listOfReviewsDtoForConsultant.Add(new ReviewDto{
                            Id=review.Id,
                            StarRating=review.StarRating,
                            Comment=review.Comment
                        });
                    }
                }

                foreach (var user in users)
                {
                    listOfConsultantDisplayDtos.Add(
                        new ConsultantDisplayDto
                        {
                            Id=user.Id,
                            DisplayName=user.DisplayName,
                            Image=user.ProfilePicture,
                            Bio=user.Bio,
                            NumberOfReviews=listOfReviewsDtoForConsultant.Count,
                            AverageStarReview=calculateAverageReview(listOfReviewsDtoForConsultant),
                            Reviews=listOfReviewsDtoForConsultant
                        }
                    );
                }

                return Result<List<ConsultantDisplayDto>>.Success(listOfConsultantDisplayDtos);
            }

            private int calculateAverageReview(List<ReviewDto> listOfReviews)
            {
                int totalStarRating=0;
                int averageStarRating=0;
                foreach(var review in listOfReviews)
                {
                    totalStarRating+=review.StarRating;
                }
                averageStarRating=totalStarRating/listOfReviews.Count;

                return averageStarRating;
            }
        }
    }
}