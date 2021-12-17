using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Repositories.JobApplications;
using MediatR;

namespace Application.JobApplications
{
	public class Create
	{
		public class Command : IRequest<Result<Unit>>
		{
			public JobApplicationDto JobApplication { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly IJobApplicationRepository _jobApplicationRepository;
			private readonly IEmailSender _emailSender;

			public Handler(IJobApplicationRepository jobApplicationRepository, IEmailSender emailSender)
			{
				_jobApplicationRepository = jobApplicationRepository;
				_emailSender = emailSender;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var result = await _jobApplicationRepository.AddAsync(request.JobApplication);

				if (result)
				{
					await _emailSender.SendEmail();

					return Result<Unit>.Success(Unit.Value);
				}
				return Result<Unit>.Failure("Nismo uspeli da sačuvamo vašu prijavu, molimo Vas da na kontaktirate kako bismo Vam pomogli");
			}
		}
	}
}
