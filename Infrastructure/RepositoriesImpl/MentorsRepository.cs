using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class MentorsRepository : IMentorsRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;

		public MentorsRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<MentorDisplayDto> GetMentorAsync(string id)
		{
			return await _context.Users
				.Where(u => u.Id == id)
				.ProjectTo<MentorDisplayDto>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync();
		}

		public async Task<Tuple<IEnumerable<MentorDisplayDto>,int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category)
		{
			var usersInRole = await _userManager.GetUsersInRoleAsync("Mentor");

			var usersInCategory = usersInRole
				.Where(u => category != null ? u.Categories
				.Any(c => c.Category.Name == category) : true);

			int totalRecords = usersInCategory.Count();

			return new Tuple<IEnumerable<MentorDisplayDto>, int>(_mapper.Map<IEnumerable<MentorDisplayDto>>(usersInCategory
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)),totalRecords);
		}

		public async Task<int> GetTotalNumberOfMentors()
		{
			return await _context.Users.CountAsync();
		}
	}
}
