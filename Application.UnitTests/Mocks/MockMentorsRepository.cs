using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using AutoFixture;
using Moq;

namespace Application.UnitTests.Mocks
{
	public class MockMentorsRepository
	{
		/*public Mock<IMentorsRepository> GetMentorsRepository(int pageNumber, int pageSize)
		{
			var fixture = new Fixture();
			var mentors = fixture.Build<IEnumerable<MentorDisplayDto>>().Create();

			var mockRepo = new Mock<IMentorsRepository>();

			mockRepo.Setup(x => x.GetMentorsPaginatedAsync(pageNumber, pageSize)).ReturnsAsync(mentors);
		}*/
	}
}
