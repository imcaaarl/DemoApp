using AuthSvc.Authentication;
using AuthSvc.Models;
using AuthSvc.Repositories;
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
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            var authResult = await _userRepository.GetUserAsync(request);
            if (authResult == null) return Unauthorized();
            var authResponce = _jwtTokenHandler.GenerateJwtToken(authResult);
            if (authResponce == null) return Unauthorized();
            return authResponce;
        }
    }
}
