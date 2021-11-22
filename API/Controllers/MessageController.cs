using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MessageController:BaseApiController
    {
        // [HttpPost("{MentorId}")]
        // public async Task<IActionResult> Send(string MentorId,Message message)
        // {
        //     return Ok(await Mediator.Send(new Application.Messages.Send.Command{MentorId=MentorId,Message=message}));
        // }
    }
}