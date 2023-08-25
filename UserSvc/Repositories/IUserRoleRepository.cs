using UserSvc.Models;

namespace UserSvc.Repositories
{
    public interface IUserRoleRepository
    {
        public Task<List<UserRole>> GetUserRolesAsync();
        public Task<UserRole> GetUserRolesByIdAsync(int id);

    }
}
