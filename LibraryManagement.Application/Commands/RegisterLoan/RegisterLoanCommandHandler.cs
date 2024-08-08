using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Commands.RegisterLoan
{
    internal class RegisterLoanCommandHandler : IRequestHandler<RegisterLoanCommand, int>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public RegisterLoanCommandHandler(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public async Task<int> Handle(RegisterLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.BookId);
            if (book == null || book.Status != BookStatusEnum.BookInTheLibrary)
            {
                throw new ArgumentException("Book not found");
            }

            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var loan = new Loan
            {
                BookId = request.BookId,
                UserId = request.UserId,
                BorrowedOnDate = DateTime.Now                
            };

            await _loanRepository.RegisterLoanAsync(loan);

            return loan.Id;
        }
    }
}
