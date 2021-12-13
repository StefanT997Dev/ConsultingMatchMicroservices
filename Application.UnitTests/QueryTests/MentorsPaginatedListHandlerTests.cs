using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using Application.Mentors;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.UnitTests.QueryTests
{
	public class MentorsPaginatedListHandlerTests : HandlerBase
	{
		private readonly Mock<IMentorsRepository> _mentorsRepository;
		private readonly PaginatedList.Handler _sut; 
		public MentorsPaginatedListHandlerTests()
		{
			_mentorsRepository = new Mock<IMentorsRepository>();
		}

		[Fact]
		public async Task Handle_NoMentorsInDb_ReturnsFailureResult()
		{
			var fixture = new Fixture();
			var listOfMentors = fixture.Build<MentorDisplayDto>().CreateMany(0);
			_mentorsRepository.Setup(repo => repo.GetMentorsPaginatedAsync(
				It.IsAny<int>(),
				It.IsAny<int>(),
				It.IsAny<string>()))
				.ReturnsAsync(new Tuple<IEnumerable<MentorDisplayDto>,int>(listOfMentors,0));

			var result = _sut.Handle(,cancellationToken);
		}
	}
}
