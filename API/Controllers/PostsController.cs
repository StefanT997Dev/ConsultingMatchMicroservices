namespace API.Controllers
{
	public class PostsController:BaseApiController
    {
       /* [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return HandleResultForLists(await Mediator.Send(new List.Query()));
        }*/

        /*[HttpGet("{id}")] 
        public async Task<IActionResult> GetPost(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id=id}));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Mentor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(Guid id,Post post)
        {
            post.Id=id;
            return HandleResult(await Mediator.Send(new Edit.Command{Post=post}));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Mentor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id=id}));
        }*/
    }
}