using Application.Interfaces.Repositories.AppUserCategories;
using AutoMapper;
using Domain;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class AppUserCategoriesRepository : Repository<AppUserCategory>, IAppUserCategoriesRepository
	{
		public AppUserCategoriesRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
