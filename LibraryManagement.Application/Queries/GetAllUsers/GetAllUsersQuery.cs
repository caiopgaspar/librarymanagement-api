using LibraryManagement.Application.ViewModels;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
