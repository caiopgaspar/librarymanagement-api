namespace LibraryManagement.Core.Entities
{
    public class Loan
    {
        public Loan(int id, int userId, int bookId, DateTime borrowedOnDate)
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            BorrowedOnDate = borrowedOnDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOnDate { get; set; }
        public DateTime ReturnedOnDate { get; set; }
    }
}
