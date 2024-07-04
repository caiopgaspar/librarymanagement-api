using LibraryManagement.Application.Queries.GetAllUsers;
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
    }
}
