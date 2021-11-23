using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;
using Application.Interfaces.Repositories.Mentors;
using Application.Core.Wrappers;
using Microsoft.Extensions.Localization;

namespace Application.Mentors
{
	public class PaginatedList
    {
        public class Query : IRequest<PagedResult<List<MentorDisplayDto>>> 
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
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
                var mentors = await _mentorsRepository.GetMentorsPaginatedAsync(request.PageNumber, request.PageSize);

                var mentorsList = mentors.ToList();

                if (mentorsList.Count == 0)
                {
                    return PagedResult<List<MentorDisplayDto>>
                        .Failure("Based on the page number and page size we couldn't find any mentors");
                }

                int totalRecords = await _mentorsRepository.GetTotalNumberOfMentors();

                int numberOfPages = CalculateNumberOfPages(request, totalRecords);

                return PagedResult<List<MentorDisplayDto>>.Success(mentorsList, numberOfPages, totalRecords);
            }

			private static int CalculateNumberOfPages(Query request, int totalRecords)
			{
                return ((totalRecords - 1) / request.PageSize) + 1;
            }
		}
    }
}