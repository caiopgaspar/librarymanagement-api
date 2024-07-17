using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler (IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        async Task<BookViewModel> IRequestHandler<GetBookByIdQuery, BookViewModel>.Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            if (book == null) return null;  //padrão result          
                        
            var booksViewModel = new BookViewModel(book.Id, book.Title, book.Author, book.Isbn, book.YearOfPublication);

            return booksViewModel;
        }
    }
}
