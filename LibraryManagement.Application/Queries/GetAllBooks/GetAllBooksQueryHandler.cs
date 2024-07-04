using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksAsync();

            var booksViewModel = books
                .Select(b => new BookViewModel(b.Id, b.Title, b.Author, b.Isbn, b.YearOfPublication))
                .ToList();
            
            return booksViewModel;
        }    
    }
}
