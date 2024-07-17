using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.Books
                .Where(b => b.Status != BookStatusEnum.BookDeleted)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id && b.Status != BookStatusEnum.BookDeleted);
        }

        public async Task RegisterNewBookAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            book.Status = BookStatusEnum.BookDeleted;
            await _dbContext.SaveChangesAsync();

        }
    }
}
