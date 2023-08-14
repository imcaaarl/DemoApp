using AuthSvc.Models;

namespace AuthSvc.Repositories
{
    public interface IUserAccountRepository
    {
        public Task<UserAccount> GetUserAsync(AuthRequest authRequest);
    }
}
