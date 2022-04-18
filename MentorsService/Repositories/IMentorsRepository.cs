using MentorsService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsService.Repositories
{
	public interface IMentorsRepository
	{
		Task<bool> AddAsync(Mentor mentor);
		Task<IEnumerable<Mentor>> GetAllAsync();
	}
}
