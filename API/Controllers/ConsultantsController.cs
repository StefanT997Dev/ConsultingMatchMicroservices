using System.Threading.Tasks;
using Application.Consultants;
using Application.Posts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ConsultantsController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetConsultants()
        {
            return HandleResultForLists(await Mediator.Send(new Application.Consultants.List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetReviews(string id)
        {
            return HandleResultForLists(await Mediator.Send(new Application.Reviews.List.Query{Id=id}));
        }

        [AllowAnonymous]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostReview(string id,Review review)
        {
            return Ok(await Mediator.Send(new Application.Reviews.Create.Command{Id=id,Review=review}));
        }

        [AllowAnonymous]
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetPosts(string id)
        {
            return HandleResultForLists(await Mediator.Send(new ListForConsultant.Query{Id=id}));
        }

        [AllowAnonymous]
        [HttpPost("{id}/posts")]
        public async Task<IActionResult> PostAPost(string id,Post post)
        {
            return Ok(await Mediator.Send(new CreateAPost.Command{Id=id,Post=post}));
        }
    }
}