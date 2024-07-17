using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
        Task<User> GetUserByEmailAsync(string email);
    }
}
