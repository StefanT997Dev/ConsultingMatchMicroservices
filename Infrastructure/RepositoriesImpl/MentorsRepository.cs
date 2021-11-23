using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Wrappers;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class MentorsRepository : IMentorsRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public MentorsRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<MentorDisplayDto> GetMentorAsync(string id)
		{
			return await _context.Users
				.Include(u => u.Categories)
				.Include(u => u.ClientReviews)
				.Where(u => u.Id == id)
				.ProjectTo<MentorDisplayDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<MentorDisplayDto>> GetMentorsPaginatedAsync(int pageNumber, int pageSize)
		{
			return await _context.Users
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.ProjectTo<MentorDisplayDto>(_mapper.ConfigurationProvider)
					.ToListAsync();
		}

		public async Task<int> GetTotalNumberOfMentors()
		{
			return await _context.Users.CountAsync();
		}
	}
}
