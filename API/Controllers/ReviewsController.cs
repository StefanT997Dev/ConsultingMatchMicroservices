using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Reviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ReviewsController:BaseApiController
	{
		[Authorize(AuthenticationSchemes = "Bearer", Roles = "Client")]
		[HttpPost]
		public async Task<IActionResult> HasLeftAReview(MentorDto mentor)
		{
			return HandleResult(await Mediator.Send(new Exists.Command { MentorId = mentor.Id }));
		}
	}
}
