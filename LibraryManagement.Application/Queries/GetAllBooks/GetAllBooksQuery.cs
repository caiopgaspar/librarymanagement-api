using LibraryManagement.Application.ViewModels;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
        public GetAllBooksQuery(string query)
        {
            Query = query;            
        }
        public string Query { get; private set; }
    }
}
