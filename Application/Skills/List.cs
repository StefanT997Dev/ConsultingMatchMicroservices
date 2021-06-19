using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
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
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SkillDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var category = _context.Categories
                    .Include(c => c.Skills)
                    .ThenInclude(cs => cs.Skill)
                    .FirstOrDefault(c => c.Id==request.CategoryId);

                var listOfSkills = new List<SkillDto>();

                foreach(var skill in category.Skills)
                {
                    listOfSkills.Add(new SkillDto{Id=skill.SkillId,Name=skill.Skill.Name});
                }

                return Result<List<SkillDto>>.Success(listOfSkills);
            }
        }
    }
}