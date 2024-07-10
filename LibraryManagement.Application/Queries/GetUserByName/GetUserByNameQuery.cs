using LibraryManagement.Application.ViewModels;
using MediatR;

namespace LibraryManagement.Application.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<UserViewModel>
    {
        public GetUserByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
