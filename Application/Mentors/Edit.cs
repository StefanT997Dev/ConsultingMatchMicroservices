using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Mentors
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
			public UpdateMentorDto Mentor { get; set; }
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
				var mentor = await _context.Users.FindAsync(request.Mentor.Id);

				if (mentor == null) return null;

				var mentorSkills = await _context.AppUserSkills
					.Where(aus => aus.MentorId == mentor.Id)
					.ToListAsync();

				_mapper.Map(request.Mentor.Skills, mentorSkills);

				_mapper.Map(request.Mentor, mentor);

				var result = await _context.SaveChangesAsync() > 0;

				if (!result) return Result<Unit>.Failure("Nismo uspeli da sačuvamo izmene");

				return Result<Unit>.Success(Unit.Value);
			}
		}
	}
}
