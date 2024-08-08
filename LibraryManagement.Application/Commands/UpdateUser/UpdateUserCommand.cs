using MediatR;

namespace LibraryManagement.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
