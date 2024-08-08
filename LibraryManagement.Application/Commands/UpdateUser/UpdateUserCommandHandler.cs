using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                throw new NullReferenceException($"User with ID {request.Id} not found.");
            }

            user.UpdateUser(request.Name, request.Email);

            await _userRepository.SaveChangesAsync();

            return user.Id;           
        }
    }
}
