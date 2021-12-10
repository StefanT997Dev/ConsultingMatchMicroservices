using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
    public class Choose
    {
        public class Command : IRequest<Result<Unit>>
        {
            public List<SkillDto> Skills { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
			private readonly IMapper _mapper;
			private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(IMapper mapper, DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
				_mapper = mapper;
				_context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var mentor = await _context.Users
                    .AsNoTracking()
                    .Where(u => u.UserName == _userAccessor.GetUsername())
                    .ProjectTo<MentorDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

                var appUserSkillsList = new List<AppUserSkill>();

                foreach (var skill in request.Skills)
                {
                    var appUserSkill = new AppUserSkill
                    {
                        MentorId = mentor.Id,
                        SkillId = skill.Id
                    };

                    appUserSkillsList.Add(appUserSkill);
                }

                _context.AppUserSkills.AddRange(appUserSkillsList);

                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}