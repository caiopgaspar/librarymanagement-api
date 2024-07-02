using LibraryManagement.Core.Entities;
using LibraryManagement.Infrastructure.Persistence;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {    
        private readonly BooksDbContext _context;
        public BooksController(BooksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }        
    }
}
