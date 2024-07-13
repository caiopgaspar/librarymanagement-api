using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BooksDbContext _dbContext;
        public LoanRepository(BooksDbContext booksDbContext)
        {
            _dbContext = booksDbContext;            
        }
        public async Task<List<Loan>> GetAllLoansAsync()
        {
            return await _dbContext.Loans
                .ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(Guid loanId)
        {
            return await _dbContext.Loans.SingleOrDefaultAsync(l => l.IdLoan == loanId);
        }

        public async Task RegisterLoanAsync(Loan loan)
        {
            await _dbContext.Loans.AddAsync(loan);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RegisterReturnAsync(Guid loanId)
        {
            var loan = await GetLoanByIdAsync(loanId);
            if (loan == null)
            {
                throw new ArgumentException("Loan not found");
            }

            loan.RegisterReturn();

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
