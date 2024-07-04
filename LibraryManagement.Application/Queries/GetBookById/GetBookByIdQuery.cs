using LibraryManagement.Application.ViewModels;
using MediatR;

namespace LibraryManagement.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
