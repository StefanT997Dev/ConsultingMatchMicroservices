using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Profiles;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class ListOfConsultants
    {
        public class Query : IRequest<Result<ICollection<Profile>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ICollection<Profile>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<ICollection<Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var selectedCategory= _context.Categories
                    .Include(c => c.Consultants)
                    .ThenInclude(ac => ac.AppUser)
                    .FirstOrDefault(c => c.Id==request.Id);

                var listOfReviews = new List<Review>();

                var listOfProfiles = new List<Profile>();

                foreach(var consultant in selectedCategory.Consultants)
                {
                    var reviews = await _context.Reviews.Where(r => r.Consultant.Id==consultant.AppUserId).ToListAsync();

                    var listOfReviewsDtoForConsultant = new List<ReviewDto>();

                    foreach(var review in reviews)
                    {
                        listOfReviewsDtoForConsultant.Add(new ReviewDto{
                            Id=review.Id,
                            StarRating=review.StarRating,
                            Comment=review.Comment
                        });
                        
                    }

                    listOfProfiles.Add(
                    new Profile
                    {
                        Id=consultant.AppUserId,
                        DisplayName=consultant.AppUser.DisplayName,
                        Image=consultant.AppUser.ProfilePicture,
                        Bio=consultant.AppUser.Bio,
                        NumberOfReviews=reviews.Count,
                        AverageStarReview=calculateAverageReview(listOfReviewsDtoForConsultant),
                        Reviews=listOfReviewsDtoForConsultant
                    });
                }

                return Result<ICollection<Profile>>.Success(listOfProfiles);
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