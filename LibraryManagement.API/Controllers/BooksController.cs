﻿using LibraryManagement.Application.Commands.DeleteBook;
using LibraryManagement.Application.Commands.RegisterNewBook;
using LibraryManagement.Application.Commands.UpdateBook;
using LibraryManagement.Application.Queries.GetAllBooks;
using LibraryManagement.Application.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(string query)
        {
            var getAllBooksQuery = new GetAllBooksQuery(query);

            var book = await _mediator.Send(getAllBooksQuery);

            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var getBookById = new GetBookByIdQuery(id);

            var book = await _mediator.Send(getBookById);

            return Ok(book);
        }

        [HttpPost("registernewbook")]
        public async Task<IActionResult> RegisterNewBook([FromBody] RegisterNewBookCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(RegisterNewBook), new { id }, command);
        }

        [HttpPut("updatebook/{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
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

        [HttpDelete("deletebook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteBookCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
