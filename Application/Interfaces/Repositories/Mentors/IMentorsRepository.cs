using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces.Repositories.Mentors
{
	public interface IMentorsRepository
	{
		Task<IEnumerable<MentorDisplayDto>> GetMentorsPaginatedAsync(int pageNumber, int pageSize);
		Task<int> GetTotalNumberOfMentors();
		Task<MentorDisplayDto> GetMentorAsync(string id);
	}
}
