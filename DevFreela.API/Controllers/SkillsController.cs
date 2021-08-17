
using DevFreela.Application.Query.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            var query = new GetAllSkillsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
