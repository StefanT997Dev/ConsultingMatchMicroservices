using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Categories
{
	public class ListOfMentors
    {
        public class Query : IRequest<Result<ICollection<MentorDisplayDto>>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ICollection<MentorDisplayDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ICollection<MentorDisplayDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
            

                /*if (selectedCategory == null)
                {
                    return Result<ICollection<MentorDisplayDto>>.Failure("Za ovu kategoriju trenutno nemamo nijednog mentora");
                }*/

                return Result<ICollection<MentorDisplayDto>>.Success(new List<MentorDisplayDto>());
            }
        }
    }
}