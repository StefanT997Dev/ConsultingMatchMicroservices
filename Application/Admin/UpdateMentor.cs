using Application.Core;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Admin
{
	public class UpdateMentor
	{
		public class Command : IRequest<Result<Unit>>
		{
			public AdminUpdateMentorDto UpdateMentorDto { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IMapper mapper)
			{
				_context = context;
				_mapper = mapper;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var user = await _context.Users
					.Include(x => x.Role)
					.FirstOrDefaultAsync(x => x.UserName == request.UpdateMentorDto.Username
						&& x.Role.Name == request.UpdateMentorDto.PreviousRole);

				if (user == null)
				{
					return Result<Unit>.Failure("Nismo uspeli da pronađemo korisnika u bazi podataka");
				}

				if (request.UpdateMentorDto.NewRole != null)
				{
					var roleDto = await _context.Roles
						.ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
						.FirstOrDefaultAsync(x => x.Name == request.UpdateMentorDto.NewRole);

					if (roleDto == null)
					{
						return Result<Unit>.Failure("Nismo uspeli da pronađemo prosleđenu ulogu");
					}

					user.RoleId = roleDto.Id;
				}

				if (request.UpdateMentorDto.PriceRate != MentorPriceRateEnum.DEFAULT)
				{
					user.PriceRate = request.UpdateMentorDto.PriceRate;
				}

				var result = await _context.SaveChangesAsync()>0;

				if (!result)
				{
					return Result<Unit>.Failure("Nismo uspeli da ažuriramo mentora");
				}

				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}
