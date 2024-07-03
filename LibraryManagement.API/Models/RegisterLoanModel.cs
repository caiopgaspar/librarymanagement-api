namespace LibraryManagement.API.Models
{
    public class RegisterLoanModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOnDate { get; set; }
    }
}
