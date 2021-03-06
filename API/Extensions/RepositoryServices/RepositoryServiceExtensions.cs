using Application.Interfaces.Repositories;
using Application.Interfaces.Repositories.AppUserCategories;
using Application.Interfaces.Repositories.Categories;
using Application.Interfaces.Repositories.JobApplications;
using Application.Interfaces.Repositories.Mentors;
using Application.Interfaces.Repositories.Mentorship;
using Application.Interfaces.Repositories.Reviews;
using Infrastructure.RepositoriesImpl;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions.RepositoryServices
{
	public static class RepositoryServiceExtensions
	{
		public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
		{
			services.AddScoped<IMentorsRepository, MentorsRepository>();
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();
			services.AddScoped<IAppUserCategoriesRepository, AppUserCategoriesRepository>();
			services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
			services.AddScoped<IReviewsRepository, ReviewsRepository>();
			services.AddScoped<IMentorshipRepository, MentorshipRepository>();

			return services;
		}
	}
}