using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        
        Task RegisterNewBookAsync(Book book);

        Task<Book> GetBookByIdAsync(int id);

        Task SaveChangesAsync();
        Task DeleteBookAsync(Book book);
    }
}
