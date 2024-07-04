using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _dbContext;
        public BookRepository(BooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }        

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task RegisterNewBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
