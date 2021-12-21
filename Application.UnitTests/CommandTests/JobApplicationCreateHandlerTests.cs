using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.JobApplications;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.JobApplications.Create;

namespace Application.UnitTests.CommandTests
{
	public class JobApplicationCreateHandlerTests
	{
		private readonly Handler _sut;
		private readonly Mock<IJobApplicationRepository> _repository;
		private readonly Mock<IEmailSender> _emailSender;
		private Command _command;
		private readonly CancellationToken _cancellationToken;
		private readonly DataContext _dataContext;
		private readonly Mock<DbContextOptions> _dbContextOptions;
		public JobApplicationCreateHandlerTests()
		{
			_repository = new Mock<IJobApplicationRepository>();
			_emailSender = new Mock<IEmailSender>();
			_dbContextOptions = new Mock<DbContextOptions>();
			_dataContext = new DataContext(_dbContextOptions.Object);
			_sut = new Handler(_repository.Object, _emailSender.Object, _dataContext);
			_cancellationToken = new CancellationToken();
		}

		[Theory]
		[InlineData(true, true)]
		[InlineData(false, false)]
		public async Task Handle_WhetherJobApplicationIsCreated_ReturnsAdequateResult(
				bool isCreated,
				bool isSuccess
			)
		{
			var fixture = new Fixture();
			var jobApplicationDto = fixture.Create<JobApplicationDto>();
			_repository
				.Setup(x => x.AddAsync(jobApplicationDto))
				.ReturnsAsync(isCreated);
			_command = new Command
			{
				JobApplication = jobApplicationDto
			};

			var result = await _sut.Handle(_command, _cancellationToken);

			Assert.Equal(isSuccess, result.IsSuccess);
		}
	}
}
