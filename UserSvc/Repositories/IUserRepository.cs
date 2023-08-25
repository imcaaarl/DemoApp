using UserSvc.Models;
using UserSvc.Requests;

namespace UserSvc.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task AddUserAsync(User user);
        public Task<bool> UpdateUserAsync(UserByIdRequest user);
        public Task<bool> DeleteUserAsync(int Id);
    }
}
