using LibraryManagement.Application.Commands.CreateUser;
using LibraryManagement.Application.Commands.UpdateUser;
using LibraryManagement.Application.Queries.GetAllUsers;
using LibraryManagement.Application.Queries.GetUserById;
using LibraryManagement.Application.Queries.GetUserByEmail;
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

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var getUserByEmail = new GetUserByEmailQuery(email);

            var user = await _mediator.Send(getUserByEmail);

            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateUser), new { id }, command);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
