using LibraryManagement.Core.Enums;

namespace LibraryManagement.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan()
        {
        }

        public Loan(int userId, int bookId, DateTime borrowedOnDate)
        {
            UserId = userId;
            BookId = bookId;
            BorrowedOnDate = borrowedOnDate;
            Status = LoanStatusEnum.Active;
        }

        public Guid IdLoan { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOnDate { get; set; }
        public DateTime? ReturnedOnDate { get; set; }
        public LoanStatusEnum Status { get; set; }

        public void RegisterReturn()
        {
            Status = LoanStatusEnum.Returned;
            ReturnedOnDate = DateTime.Now;
        }
    }
}
