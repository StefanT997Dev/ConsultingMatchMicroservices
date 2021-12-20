using Application.Interfaces.Repositories.Reviews;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class ReviewsRepository : Repository<Review>, IReviewsRepository
	{
		public ReviewsRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
