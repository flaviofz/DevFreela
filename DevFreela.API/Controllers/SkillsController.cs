
using DevFreela.Application.Command.CreateSkill;
using DevFreela.Application.Query.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;
        private const string GET_SKILLS_CACHE = "GET_SKILLS";

        public SkillsController(
            IMediator mediator, 
            IMemoryCache memoryCache
        )
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            if (_memoryCache.TryGetValue(GET_SKILLS_CACHE, out List<SkillsViewModel> skills))
                return Ok(skills);

            var query = new GetAllSkillsQuery();

            var result = await _mediator.Send(query);

            var memoryCacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600), // Passa 1 hora e invalida
                SlidingExpiration = TimeSpan.FromSeconds(1200) // Passa 20 minutos seguidos sem requisição invalida
            };
            
            _memoryCache.Set(GET_SKILLS_CACHE, result, memoryCacheOptions);

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
