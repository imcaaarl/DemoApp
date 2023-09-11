using AuthSvc.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthSvc.Authentication
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "0D5BACE90F56EBB566FE3D41E7C49AB04A9BD84F2ED5F8777678D7CDB6F1585F";
        public const string REFRESH_SECURITY_KEY = "8S5D45FG55O8G5JLS25F5GHBNX58SG5624HBBA2S5S23V5N5C2G4Q5Y4N7S8FG23HG6FH";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private const int REFRESH_TOKEN_VALIDITY_MINS = 30;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public jwt? GenerateJwtToken(UserAccount userAccount)
        {
            if (string.IsNullOrWhiteSpace(userAccount.Email) || string.IsNullOrWhiteSpace(userAccount.Password))
            {
                return null;
            }

            if (userAccount == null)
            {
                return null;
            }

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var refreshTokenExpiryTimeStamp = DateTime.Now.AddMinutes(REFRESH_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Sub,userAccount.Id.ToString()),
                new Claim (JwtRegisteredClaimNames.Name,userAccount.Email),
                new Claim("UserRoleCode",userAccount.tbluserroles.UserRoleCode.ToString()),
            },CookieAuthenticationDefaults.AuthenticationScheme);

            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);
            var refreshToken = Guid.NewGuid().ToString();

            var response = _httpContextAccessor.HttpContext.Response;
            response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = tokenExpiryTimeStamp,
                Path = "/",
            });
            response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = refreshTokenExpiryTimeStamp,
                Path = "/refresh",
            });
            return new jwt
            {
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = token,
                
            };
        }

        public ClaimsPrincipal VerifyRefreshToken(string refreshToken)
        {
            var refreshToken = Request.C
        }
    }
}