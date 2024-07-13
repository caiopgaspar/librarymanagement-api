using MediatR;

namespace LibraryManagement.Application.Commands.RegisterReturn
{
    public class RegisterReturnCommand : IRequest<Guid>
    {
        public Guid LoanId { get; set; }
    }
}
