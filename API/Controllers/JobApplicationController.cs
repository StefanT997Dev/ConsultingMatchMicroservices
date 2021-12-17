using System.Threading.Tasks;
using Application.DTOs;
using Application.JobApplications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class JobApplicationController:BaseApiController
	{
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Create(JobApplicationDto jobApplication)
		{
			return HandleResult(await Mediator.Send(new Create.Command { JobApplication = jobApplication }));
		}
	}
}
