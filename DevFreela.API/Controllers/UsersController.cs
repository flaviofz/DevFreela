using DevFreela.Application.Command.CreateUser;
using DevFreela.Application.Command.LoginUser;
using DevFreela.Application.Query.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        // [Authorize(Roles = "client")]
        // [Authorize(Roles = "client, freelancer")]
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
                createUserInputModel.BirthDate,
                createUserInputModel.Password,
                createUserInputModel.Role
            );

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserCommand loginUserCommand
        )
        {
            var loginUserViewModel = await _mediator.Send(loginUserCommand);

            return Ok(loginUserViewModel);
        }
    }
}
