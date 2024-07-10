using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Commands.RegisterNewBook
{
    public class RegisterNewBookCommandHandler : IRequestHandler<RegisterNewBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public RegisterNewBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(RegisterNewBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Author, request.Isbn, request.YearOfPublication);

            await _bookRepository.RegisterNewBookAsync(book);

            return book.Id;
        }
    }
}
