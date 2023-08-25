using Microsoft.AspNetCore.Mvc;
using UserSvc.Models;
using UserSvc.Repositories;

namespace UserSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserRoleController
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRole>>> GetUserRoles()
        {
            return await _userRoleRepository.GetUserRolesAsync();
        }
    }
}
