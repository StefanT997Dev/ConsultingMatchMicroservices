using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
    public class List
    {
        public class Query : IRequest<Result<List<SkillDto>>>
        {
            public Guid CategoryId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<SkillDto>>>
        {
            private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
				_mapper = mapper;
			}

            public async Task<Result<List<SkillDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories
                    .Where(c => c.Id == request.CategoryId)
                    .Include(c => c.Skills)
                    .ThenInclude(cs => cs.Skill)
                    .ProjectTo<CategoryWithSkillsDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                return Result<List<SkillDto>>.Success(category.Skills.ToList());
            }
        }
    }
}