using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Commands.RegisterReturn
{
    public class RegisterReturnCommandHandler : IRequestHandler<RegisterReturnCommand, Guid>
    {
        private readonly ILoanRepository _loanRepository;
        public RegisterReturnCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<Guid> Handle(RegisterReturnCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.LoanId);

            if (loan.Status != LoanStatusEnum.Active || loan.Status == null || loan == null)
            {
                throw new ArgumentException("Loan not found");
            }

            loan.RegisterReturn();
            await _loanRepository.RegisterLoanAsync(loan);
            
            return loan.IdLoan;
        }
    }
}
