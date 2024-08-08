using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using MediatR;

namespace LibraryManagement.Application.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;            
        }
        public async Task<UserViewModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByNameAsync(request.Email);
            
            if (user == null) return null;
            
            var userViewModel = new UserViewModel(user.Id, user.Name, user.Email);

            return userViewModel;
        }
    }
}
