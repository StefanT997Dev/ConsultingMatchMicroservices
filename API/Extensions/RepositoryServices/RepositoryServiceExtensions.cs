using Application.Interfaces.Repositories.Mentors;
using Infrastructure.RepositoriesImpl;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.RepositoryServices
{
	public static class RepositoryServiceExtensions
	{
		public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IMentorsRepository, MentorsRepository>();

			return services;
		}
	}
}