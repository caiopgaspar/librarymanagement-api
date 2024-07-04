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
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int YearOfPublication { get; set; }
    }
}
