using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BooksDbContext _dbContext;
        public UserRepository(BooksDbContext dbContext)
        {
            _dbContext = dbContext;            
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users
                .ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            //return await _dbContext.Users.FindAsync(id);
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == name);
        }
    }
}
