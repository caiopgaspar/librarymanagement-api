using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllLoansAsync();
        //Task<Loan> GetLoanByUser(User user);
        Task RegisterLoanAsync(Loan loan);
        Task SaveChangesAsync();
        Task RegisterReturnAsync(int loanId);
        Task<Loan> GetLoanByIdAsync(int loanId);
    }
}
