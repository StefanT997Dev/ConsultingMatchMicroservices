using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces.Repositories.Mentors
{
	public interface IMentorsRepository: IRepository<MentorDisplayDto, string>
	{
		Task<Tuple<IEnumerable<MentorDisplayDto>, int>> GetMentorsPaginatedAsync(int pageNumber, int pageSize, string category);
		Task<int> GetTotalNumberOfMentors();
	}
}
