using LibraryManagement.Application.Commands.RegisterLoan;
using LibraryManagement.Application.Commands.RegisterReturn;
using LibraryManagement.Application.Queries.GetAllLoans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/loans")]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetLoans(string query)
        {
            var getAllLoans = new GetAllLoansQuery(query);

            var loan = await _mediator.Send(getAllLoans);

            return Ok(loan);
        }

        [HttpPost("registerloan")]
        public async Task<IActionResult> RegisterLoan([FromBody] RegisterLoanCommand command)
        {
            var guid = await _mediator.Send(command);
            return CreatedAtAction(nameof(RegisterLoan), new { guid }, command);
        }

        [HttpPut("registerreturn")]
        public async Task<IActionResult> RegisterReturn(RegisterReturnCommand command)
        {
            var guid = await _mediator.Send(command);
            return Ok(new { LoanId = guid});
        }
    }
}
