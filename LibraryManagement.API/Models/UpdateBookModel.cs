namespace LibraryManagement.API.Models
{
    public class UpdateBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int YearOfPublication { get; set; }
    }
}