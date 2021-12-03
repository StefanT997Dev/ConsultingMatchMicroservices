using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.JobApplications
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public JobApplicationDto JobApplication { get; set; }
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
				var jobApplication = await _context.JobApplications
					.Where(application => application.Email == request.JobApplication.Email)
					.FirstOrDefaultAsync();

				if (jobApplication != null)
				{
					return Result<Unit>.Failure("Korisnik sa ovom email adresom se već prijavio za poziciju mentora");
				}

				_context.JobApplications.Add(_mapper.Map<MentorJobApplication>(request.JobApplication));

				var result = await _context.SaveChangesAsync() > 0;

				if (result)
				{
					return Result<Unit>.Success(Unit.Value);
				}
				return Result<Unit>.Failure("Nismo uspeli da sačuvamo vašu prijavu, molimo Vas da na kontaktirate kako bismo Vam pomogli");
			}
		}
	}
}
