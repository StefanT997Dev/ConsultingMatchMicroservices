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
	public class MentorsRepository : Repository<AppUser, string>, IMentorsRepository
	{
		public MentorsRepository(DataContext context, IMapper mapper): base(context, mapper)
		{
			
		}

		public async Task<Tuple<IEnumerable<MentorDisplayDto>,int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category)
		{
			int totalRecords = 0;
			var mentorsQuery = entities
				.Where(u => u.Roles.Any(r => r.Name == "Mentor"))
				.ProjectTo<MentorDisplayDto>(mapperConfigurationProvider)
				.AsQueryable();

			if (category != null)
			{
				mentorsQuery.Where(m => m.Categories.Any(c => c.Name == category));
				totalRecords = await mentorsQuery.CountAsync();
			}
			else
			{
				totalRecords = await mentorsQuery.CountAsync();
			}

			return new Tuple<IEnumerable<MentorDisplayDto>, int>(await mentorsQuery
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync(),totalRecords);
		}
	}
}
