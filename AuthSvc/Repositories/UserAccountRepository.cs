using AuthSvc.Data;
using AuthSvc.Models;
using AuthSvc.Repositories;
using AuthSvc.ViewModel;
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
            //var data = await _dbContext.tblusers
            //    .Where(u=>u.UserRoleId==u.tbluserroles.Id)
            //    .Where(t=>t.user)
            //    .Select(u=>new UserRole
            //    {
            //        Id=u.tbluserroles.Id,
            //        UserRoleCode=u.tbluserroles.UserRoleCode,
            //        Role=u.tbluserroles.Role
            //    })


            var data = await _dbContext.tblusers.Include(u => u.tbluserroles).Include(t => t.tblusertypes)
                .FirstOrDefaultAsync(user => user.Email == authRequest.Email && user.Password == authRequest.Password);

            //var data = await _dbContext.tblusers.FirstOrDefaultAsync(user => user.Email == authRequest.Email && user.Password == authRequest.Password);

            //var vmUserAccount = new vmResUserAccount(data.FullName,data.Email,data.tbluserroles.Role,data.tbluserroles.UserRoleCode);

            return data;
        }
    }
}
