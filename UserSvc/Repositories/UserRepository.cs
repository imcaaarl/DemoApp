using UserSvc.Data;
using UserSvc.Models;
using Microsoft.EntityFrameworkCore;
using UserSvc.Repositories;

namespace UserSvc.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task AddUserAsync(User user)
        {
            var result = await _dbContext.tblusers.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> DeleteUserAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.tblusers.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.tblusers.ToListAsync();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
