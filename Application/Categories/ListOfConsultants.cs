using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Profiles;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class ListOfMentors
    {
        public class Query : IRequest<Result<ICollection<Profiles.Profile>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ICollection<Profiles.Profile>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ICollection<Profiles.Profile>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var selectedCategory = _context.Categories
                    .Include(c => c.Mentors)
                    .ThenInclude(ac => ac.AppUser)
                    .FirstOrDefault(c => c.Id == request.Id);

                var listOfReviews = new List<Review>();

                var listOfProfiles = new List<Profiles.Profile>();

                foreach (var Mentor in selectedCategory.Mentors)
                {
                    var reviews = await _context.Reviews.Where(r => r.Mentor.Id == Mentor.AppUserId).ToListAsync();

                    var listOfReviewsDtoForMentor = new List<ReviewDto>();

                    foreach (var review in reviews)
                    {
                        listOfReviewsDtoForMentor.Add(new ReviewDto
                        {
                            StarRating = review.StarRating,
                            Comment = review.Comment
                        });

                    }

                    listOfProfiles.Add(
                    new Profiles.Profile
                    {
                        Id = Mentor.AppUserId,
                        DisplayName = Mentor.AppUser.DisplayName,
                        Image = Mentor.AppUser.ProfilePicture,
                        Bio = Mentor.AppUser.Bio,
                        NumberOfReviews = reviews.Count,
                        AverageStarReview = Common.GetAverageReviewAndTotalStarRating(listOfReviewsDtoForMentor).Item2,
                        Reviews = listOfReviewsDtoForMentor
                    });
                }

                return Result<ICollection<Profiles.Profile>>.Success(listOfProfiles);
            }
        }
    }
}