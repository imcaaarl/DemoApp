using UserSvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using UserSvc.Repository;
using UserSvc.Repositories;
using AuthSvc.Authentication;

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
builder.Services.AddCustomJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
