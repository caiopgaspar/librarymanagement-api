using LibraryManagement.Core.Enums;

namespace LibraryManagement.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {           
        }

        public Book(string title, string author, string isbn, int yearOfPublication)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;

            Status = BookStatusEnum.BookInTheLibrary;
            RegisteredAt = DateTime.Now;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int YearOfPublication { get; set; }
        public List<Loan> Loans { get; set; }

        public BookStatusEnum  Status { get; set; }
        public DateTime? RegisteredAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }



        public void UpdateBook(string title, string author, string isbn, int yearOfPublication)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
        }

        public void DeleteBook()
        {
            if (Status == BookStatusEnum.BookInTheLibrary)
            {
                Status = BookStatusEnum.BookDeleted;
                DeletedAt = DateTime.Now;
            }
        }
    }
}
