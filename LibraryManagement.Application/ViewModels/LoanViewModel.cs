using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.ViewModels
{
    public class LoanViewModel
    {
        public LoanViewModel()
        {            
        }

        public LoanViewModel(Guid idLoan, int userId, int bookId, DateTime borrowedOnDate, DateTime? returnedOnDate, LoanStatusEnum status)
        {
            IdLoan = idLoan;
            UserId = userId;
            BookId = bookId;
            BorrowedOnDate = borrowedOnDate;
            ReturnedOnDate = returnedOnDate;
            Status = status;
        }

        public Guid IdLoan { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BorrowedOnDate { get; set; }
        public DateTime? ReturnedOnDate { get; set; }
        public LoanStatusEnum Status { get; set; }
    }
}
