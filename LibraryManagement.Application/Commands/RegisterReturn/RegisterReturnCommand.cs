using MediatR;

namespace LibraryManagement.Application.Commands.RegisterReturn
{
    public class RegisterReturnCommand : IRequest<int>
    {
        public int LoanId { get; set; }
    }
}
