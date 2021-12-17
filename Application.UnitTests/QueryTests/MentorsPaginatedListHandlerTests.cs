using Application.DTOs;
using Application.Interfaces.Repositories.Mentors;
using Application.Mentors;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.QueryTests
{
	public class MentorsPaginatedListHandlerTests : HandlerBase<IMentorsRepository>
	{
		private readonly PaginatedList.Handler _sut;
		private PaginatedList.Query _query;
		public MentorsPaginatedListHandlerTests()
		{
			repository = new Mock<IMentorsRepository>();
			_sut = new PaginatedList.Handler(repository.Object); 
		}

		[Theory]
		[InlineData(0, false)]
		[InlineData(5, true)]
		public async Task Handle_BasedOnMentorListLength_ReturnAdeaquateResult(
			int numberOfEntries,
			bool isSuccess)
		{
			var fixture = new Fixture();
			var listOfMentors = fixture.Build<MentorDisplayDto>().CreateMany(numberOfEntries);
			var requestFixture = new Fixture();
			var request = fixture.Build<FilterDto>().Create();
			_query = new PaginatedList.Query
			{
				Filter = request
			};
			repository.Setup(repo => repo.GetMentorsPaginatedAsync(
				It.IsAny<int>(),
				It.IsAny<int>(),
				It.IsAny<string>()))
				.ReturnsAsync(new Tuple<IEnumerable<MentorDisplayDto>,int>(listOfMentors,0));

			var result = await _sut.Handle(_query,cancellationToken);

			Assert.Equal(isSuccess, result.IsSuccess);
		}
	}
}
