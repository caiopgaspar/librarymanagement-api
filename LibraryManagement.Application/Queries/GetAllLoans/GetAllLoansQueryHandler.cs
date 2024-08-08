using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly ILoanRepository _loanRepository;
        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllLoansAsync();

            var loansViewModel = loans
                .Select(l => new LoanViewModel(
                    l.Id,
                    l.UserId,
                    l.BookId,
                    l.BorrowedOnDate,
                    l.ReturnedOnDate,
                    l.Status))
                .ToList();

            return loansViewModel;
        }
    }
}
