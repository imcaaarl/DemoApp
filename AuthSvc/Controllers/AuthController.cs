using AuthSvc.Authentication;
using AuthSvc.Models;
using AuthSvc.Repositories;
using AuthSvc.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AuthSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AuthController(JwtTokenHandler jwtTokenHandler,IUserAccountRepository userAccountRepository)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _userRepository = userAccountRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] AuthRequest request)
        {
            var vmresData = new vmResData();
            var authResult = await _userRepository.GetUserAsync(request);
            if (authResult == null) return Unauthorized("qweqewe");
            var jwt = _jwtTokenHandler.GenerateJwtToken(authResult);
            if (jwt == null) return Unauthorized();

            var vmResUserAccount = new vmResUserAccount(
                authResult.Id,authResult.FullName, authResult.Email, 
                authResult.tbluserroles.Role, authResult.tbluserroles.UserRoleCode,
                authResult.tblusertypes.Type,authResult.tblusertypes.UserTypeCode
                );

            vmresData.userAccount = vmResUserAccount;
            vmresData.jwt = jwt;

            var vmResponse = new vmResponse{ Status = "Success", Message = "Login Success!", Data = vmresData };
            return Ok(vmResponse);
        }
    }
}
