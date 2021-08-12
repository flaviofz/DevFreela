using DevFreela.API.Filters;
using DevFreela.Application.Command.CreateUser;
using DevFreela.Application.Query.GetUser;
using DevFreela.Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var query = new GetUserQuery(id);

            var result = await _mediator.Send(query);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserInputModel createUserInputModel)
        {
            // Validação feita chamando manualmente
            //var validator = new CreateUserInputModelValidator();
            //var result = validator.Validate(new CreateUserInputModel());
            //result.IsValid();

            var command = new CreateUserCommand(
                createUserInputModel.Name,
                createUserInputModel.Email,
                createUserInputModel.BirthDate
            );

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }
    }
}
