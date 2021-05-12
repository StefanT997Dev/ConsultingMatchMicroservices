using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Consultants
{
    public class Search
    {
        public class Command : IRequest<Result<List<ConsultantSearchDto>>>
        {
            public ConsultantSearchDto Consultant { get; set; }
        }

        public class Handler : IRequestHandler<Command,Result<List<ConsultantSearchDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ConsultantSearchDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                    .Where(u => u.DisplayName.StartsWith(request.Consultant.DisplayName))
                    .ToListAsync();

                var listOfConsultantSeacthDtos = new List<ConsultantSearchDto>();

                foreach(var user in users)
                {
                    listOfConsultantSeacthDtos.Add(_mapper.Map<ConsultantSearchDto>(user));
                }

                return Result<List<ConsultantSearchDto>>.Success(listOfConsultantSeacthDtos);
            }
        }
    }
}