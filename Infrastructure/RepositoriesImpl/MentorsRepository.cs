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

			// GetUsersInRoleAsync doesn't return joined tables like Categories for example
			// so we have to query the database again to get the categories additionally
			var mentors = new List<MentorDisplayDto>();

			foreach (var user in usersInRole)
			{ 
				var user1 = await _context.Users
					.Where(u => u.Id == user.Id)
					.ProjectTo<MentorDisplayDto>(_mapper.ConfigurationProvider)
					.FirstOrDefaultAsync();

				mentors.Add(user1);
			}

			var mentorsInCategory = mentors
				.Where(u => category != null ? u.Categories
				.Any(c => c.Name == category) : true)
				.ToList();

			int totalRecords = mentorsInCategory.Any()?mentorsInCategory.Count():0;

			return new Tuple<IEnumerable<MentorDisplayDto>, int>(mentorsInCategory
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize),totalRecords);
		}

		public async Task<int> GetTotalNumberOfMentors()
		{
			return await _context.Users.CountAsync();
		}
	}
}
