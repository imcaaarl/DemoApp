using UserSvc.Data;
using UserSvc.Models;
using Microsoft.EntityFrameworkCore;
using UserSvc.Repositories;
using UserSvc.Requests;

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

        public async Task<bool> UpdateUserAsync(UserByIdRequest user)
        {
            var record = await _dbContext.tblusers.FindAsync(user?.Id);
            if(record == null) { return false; }

            record.FullName = user.FullName;
            record.Email = user.Email;

            _dbContext.Entry(record).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
