using UserSvc.vmModel;
using UserSvc.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace UserSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserRoleController:ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetUserRoles()
        {
            var data= await _userRoleRepository.GetUserRolesAsync();
            if (data == null) return Ok(new vmResponse<object>("Error", "No data found", null));
            var vmRes = new vmResponse<object>("Success","Successfully fetched data!",data);
            return Ok(vmRes);
        }
    }
}