using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Reviews
{
	public class Exists
	{
		public class Command : IRequest<Result<bool>>
		{
			public string MentorId { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<bool>>
		{
			private readonly DataContext _context;
			private readonly IUserAccessor _userAccessor;
			private readonly IMapper _mapper;

			public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
			{
				_context = context;
				_userAccessor = userAccessor;
				_mapper = mapper;
			}

			public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
			{
				var client = await _context.Users
					.Where(u => u.UserName == _userAccessor.GetUsername())
					.ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync();

				if (client == null)
				{
					return Result<bool>.Failure("Nismo uspeli da Vas pronađemo u bazi podataka");
				}

				var review = await _context.Reviews.FindAsync(request.MentorId, client.Id);

				if (review == null)
				{
					return Result<bool>.Success(false);
				}

				return Result<bool>.Success(true);
			}
		}
	}
}
