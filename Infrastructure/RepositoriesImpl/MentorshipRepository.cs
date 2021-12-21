using Application.Interfaces.Repositories.Mentorship;
using AutoMapper;
using Domain;
using Persistence;

namespace Infrastructure.RepositoriesImpl
{
	public class MentorshipRepository : Repository<Mentorship>, IMentorshipRepository
	{
		public MentorshipRepository(DataContext context, IMapper mapper) : base(context, mapper)
		{
		}
	}
}
