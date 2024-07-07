using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            if (book == null)
            {                
                throw new NullReferenceException($"Book with ID {request.Id} not found.");
            } 
            else if (book.Status != BookStatusEnum.BookInTheLibrary)
            {
                throw new Exception("The book is not avaliable to update. Check the status.");
            }

            book.UpdateBook(request.Title, request.Author, request.Isbn, request.YearOfPublication);

            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}
