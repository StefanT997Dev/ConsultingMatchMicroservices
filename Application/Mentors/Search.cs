using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mentors
{
    public class Search
    {
        public class Command : IRequest<Result<List<MentorsearchDto>>>
        {
            public SkillDto Skill { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<List<MentorsearchDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<MentorsearchDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                var appUserSkills = await _context.AppUserSkills
                    .Where(aus => aus.Skill.Name.StartsWith(request.Skill.Name))
                    .Include(aus => aus.Mentor)
                    .Include(aus => aus.Skill)
                    .ToListAsync();

                var usersWithDesiredSkill = new List<AppUser>();

                foreach (var appUserSkill in appUserSkills)
                {
                    usersWithDesiredSkill.Add(appUserSkill.Mentor);
                }

                var listOfMentorseacthDtos = new List<MentorsearchDto>();

                foreach (var user in usersWithDesiredSkill)
                {
                    listOfMentorseacthDtos.Add(
                        new MentorsearchDto
                        {
                            DisplayName = user.DisplayName,
                            Skills = GetSkills(user).Result
                        }
                    );
                }
                return Result<List<MentorsearchDto>>.Success(listOfMentorseacthDtos);
            }

            private async Task<ICollection<SkillDto>> GetSkills(AppUser user)
            {
                var appUserSkills = await _context.AppUserSkills
                    .Where(aus => aus.MentorId==user.Id)
                    .Include(aus => aus.Skill)
                    .ToListAsync();

                var skillDtoList = new List<SkillDto>();

                foreach(var appUserSkill in appUserSkills)
                {
                    skillDtoList.Add(_mapper.Map<SkillDto>(appUserSkill.Skill));
                }

                return skillDtoList;
            }
        }
    }
}