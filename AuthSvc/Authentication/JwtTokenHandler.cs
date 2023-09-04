using AuthSvc.Data;
using AuthSvc.Models;
using AuthSvc.Repositories;
using AuthSvc.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthSvc.Authentication
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "0D5BACE90F56EBB566FE3D41E7C49AB04A9BD84F2ED5F8777678D7CDB6F1585F";
        private const int JWT_TOKEN_VALIDITY_MINS = 10;

        public JwtTokenHandler()
        {
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
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Name,userAccount.Email),
                new Claim("UserRoleCode",userAccount.tbluserroles.UserRoleCode.ToString()),
            });

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

            return new jwt
            {
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                Token = token,
            };
        }
    }
}
