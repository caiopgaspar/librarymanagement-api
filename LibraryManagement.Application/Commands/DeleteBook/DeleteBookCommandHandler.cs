using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.Id);

            if (book == null)
            {
                throw new NullReferenceException($"Book with ID {request.Id} not found.");
            }
            else if (book.Status != BookStatusEnum.BookInTheLibrary)
            {
                throw new Exception("The book is not avaliable to delete. Check the status.");
            }

            await _bookRepository.DeleteBookAsync(book);

            return book.Id;
        }
    }
}
