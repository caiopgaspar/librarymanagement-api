namespace LibraryManagement.Core.Entities
{
    public class Book
    {
        public Book(int id, string title, string author, string isbn, int yearOfPublication)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int YearOfPublication { get; set; }
    }
}
