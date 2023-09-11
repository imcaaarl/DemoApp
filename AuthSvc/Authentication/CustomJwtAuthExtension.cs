using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthSvc.Authentication
{
    public static class CustomJwtAuthExtension
    {
        public static void AddCustomJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenHandler.JWT_SECURITY_KEY))
                };
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.ContainsKey("AuthToken"))
                        {
                            context.Token = context.Request.Cookies["AuthToken"];
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
