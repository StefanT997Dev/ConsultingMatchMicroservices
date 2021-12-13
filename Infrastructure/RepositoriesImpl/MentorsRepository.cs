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
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoriesImpl
{
	public class MentorsRepository : Repository<AppUser, string>, IMentorsRepository
	{
		private readonly UserManager<AppUser> _userManager;

		public MentorsRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager): base(context, mapper)
		{
			_userManager = userManager;
		}

		public async Task<Tuple<IEnumerable<MentorDisplayDto>,int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category)
		{
			int totalRecords = 0;
			var mentors = entities
				.ProjectTo<MentorDisplayDto>(mapperConfigurationProvider);

			if (category != null)
			{
				mentors.Where(m => m.Categories.Any(c => c.Name == category));
				totalRecords = await mentors.CountAsync();
			}
			else
			{
				totalRecords = await mentors.CountAsync();
			}

			return new Tuple<IEnumerable<MentorDisplayDto>, int>(await mentors
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(),totalRecords);
		}
	}
}
