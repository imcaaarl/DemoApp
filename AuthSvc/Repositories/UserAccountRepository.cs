using AuthSvc.Data;
using AuthSvc.Models;
using AuthSvc.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthSvc.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserAccountRepository(ApplicationDBContext dbContext,ILogger<UserAccountRepository> logger)
        {
            _dbContext=dbContext;
        }

        public async Task<UserAccount> GetUserAsync(AuthRequest authRequest)
        {
            return await _dbContext.tblusers.FirstOrDefaultAsync(user => user.Email == authRequest.Email && user.Password == authRequest.Password);
        }
    }
}
