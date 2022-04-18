using ReviewsService.Data;
using ReviewsService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsService.Repositories
{
	public class ReviewsRepository : IReviewsRepository
	{
		private readonly DataContext _context;

		public ReviewsRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<bool> AddAsync(Review review)
		{
			_context.Reviews.Add(review);

			return await _context.SaveChangesAsync() > 0;
		}
	}
}
