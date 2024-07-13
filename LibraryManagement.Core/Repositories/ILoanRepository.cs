using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllLoansAsync();
        //Task<Loan> GetLoanByUser(User user);
        Task RegisterLoanAsync(Loan loan);
        Task SaveChangesAsync();
        Task RegisterReturnAsync(Guid loanId);
        Task<Loan> GetLoanByIdAsync(Guid loanId);
    }
}
