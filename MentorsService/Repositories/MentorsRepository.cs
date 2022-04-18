using MentorsService.Data;
using MentorsService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsService.Repositories
{
	public class MentorsRepository : IMentorsRepository
	{
		private readonly DataContext _context;

		public MentorsRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<bool> AddAsync(Mentor mentor)
		{
			_context.Mentors.Add(mentor);

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<IEnumerable<Mentor>> GetAllAsync()
		{
			return await _context.Mentors.ToListAsync();
		}
	}
}
