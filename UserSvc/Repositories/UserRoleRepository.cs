using Microsoft.EntityFrameworkCore;
using UserSvc.Data;
using UserSvc.Models;

namespace UserSvc.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRoleRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            return await _dbContext.tbluserroles.ToListAsync();
        }

        public async Task<UserRole> GetUserRolesByIdAsync(int id)
        {
            return await _dbContext.tbluserroles.FirstOrDefaultAsync(userrole => userrole.Id == id);
        }
    }
}
