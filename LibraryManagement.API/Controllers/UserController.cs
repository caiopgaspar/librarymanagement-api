using LibraryManagement.Application.Commands.CreateUser;
using LibraryManagement.Application.Queries.GetAllUsers;
using LibraryManagement.Application.Queries.GetUserById;
using LibraryManagement.Application.Queries.GetUserByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(string query)
        {
            var getAllUsersQuery = new GetAllUsersQuery(query);

            var user = await _mediator.Send(getAllUsersQuery);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getUserById = new GetUserByIdQuery(id);

            var user = await _mediator.Send(getUserById);

            return Ok(user);
        }

        [HttpGet("byname/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var getUserByName = new GetUserByNameQuery(name);

            var user = await _mediator.Send(getUserByName);

            return Ok(user);
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUsers([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateUsers), new { id }, command);
        }
    }
}
