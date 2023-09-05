using UserSvc.Data;
using Microsoft.EntityFrameworkCore;
using UserSvc.Repository;
using UserSvc.Repositories;
using AuthSvc.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConn");

builder.Services.AddDbContextPool<ApplicationDBContext>(options => options.UseMySql(
    mySqlConnectionStr,ServerVersion.AutoDetect(mySqlConnectionStr)
    ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AuthToken";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
//builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
