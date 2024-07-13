using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using MediatR;
using System.Data;

namespace LibraryManagement.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email
            };
            
            await _userRepository.CreateUserAsync(user);

            return user.Id;
        }
    }
}
