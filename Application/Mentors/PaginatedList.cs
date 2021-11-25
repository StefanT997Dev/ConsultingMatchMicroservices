using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;
using Application.Interfaces.Repositories.Mentors;
using Application.Core.Wrappers;
using System;

namespace Application.Mentors
{
	public class PaginatedList
    {
        public class Query : IRequest<PagedResult<List<MentorDisplayDto>>> 
        {
			public FilterDto Filter { get; set; }
		}

		public class Handler : IRequestHandler<Query, PagedResult<List<MentorDisplayDto>>>
        {
            private readonly IMentorsRepository _mentorsRepository;

			public Handler(IMentorsRepository mentorsRepository)
            {
				_mentorsRepository = mentorsRepository;
			}

            public async Task<PagedResult<List<MentorDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var mentors = await _mentorsRepository.GetMentorsPaginatedAsync(request.Filter.PageNumber, request.Filter.PageSize);

                var mentorsList = mentors.ToList();

                int totalRecords = 0;

                if (mentorsList.Count == 0)
                {
                    return PagedResult<List<MentorDisplayDto>>
                        .Failure("Nismo uspeli da pronađemo mentore na osnovu prosleđenih vrednosti za broj stranice i veličinu stranice");
                }

                if (request.Filter.Category != null)
                {
                    mentorsList = mentors.Where(m => (m.Categories.Any(c => c.Name == request.Filter.Category))).ToList();

                    if (mentorsList.Count == 0)
                    {
                        return PagedResult<List<MentorDisplayDto>>
                        .Failure("Nismo uspeli da pronađemo mentore na osnovu tražene kategorije");
                    }

                    totalRecords = mentorsList.Count;
                }
                else
                { 
                    totalRecords = await _mentorsRepository.GetTotalNumberOfMentors();
                }

                int numberOfPages = CalculateNumberOfPages(request, totalRecords);

                return PagedResult<List<MentorDisplayDto>>.Success(mentorsList, numberOfPages, totalRecords);
            }

			private static int CalculateNumberOfPages(Query request, int totalRecords)
			{
                return ((totalRecords - 1) / request.Filter.PageSize) + 1;
            }
		}
    }
}