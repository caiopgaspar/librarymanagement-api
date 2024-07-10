using MediatR;

namespace LibraryManagement.Application.Commands.RegisterLoan
{
    public class RegisterLoanCommand : IRequest<Guid>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOnDate { get; set; }
    }
}
