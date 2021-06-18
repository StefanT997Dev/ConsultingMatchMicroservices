using System;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Skills;

namespace API.Controllers
{
    public class SkillsController:BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Add(Guid categoryId,Skill skill)
        {
            return Ok(await Mediator.Send(new Create.Command{CategoryId=categoryId,Skill=skill}));
        }
    }
}