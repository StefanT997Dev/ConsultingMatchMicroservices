using ReviewsService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsService.Repositories
{
	public interface IReviewsRepository
	{
		Task<bool> AddAsync(Review review);
	}
}
