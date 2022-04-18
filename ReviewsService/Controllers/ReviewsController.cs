using Microsoft.AspNetCore.Mvc;
using ReviewsService.Entities;
using ReviewsService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ReviewsController : ControllerBase
	{
		private readonly IReviewsRepository _reviewsRepository;

		public ReviewsController(IReviewsRepository reviewsRepository)
		{
			_reviewsRepository = reviewsRepository;
		}

		[HttpPost]
		public async Task<IActionResult> Add(Review review)
		{
			var result = await _reviewsRepository.AddAsync(review);

			if (result)
			{
				return Ok("Success");
			}
			return BadRequest("Failure");
		}
	}
}
