using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using MediatR;

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
            var existingUserByName = await _userRepository.GetUserByNameAsync(request.Name);
            if (existingUserByName != null)
            {
                throw new ArgumentException("A user with the same name already exists.");
            }

            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("A user with the same email already exists.");
            }

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
