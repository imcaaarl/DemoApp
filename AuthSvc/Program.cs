using AuthSvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AuthSvc.Repository;
using AuthSvc.Authentication;
using AuthSvc.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConn");

builder.Services.AddDbContextPool<ApplicationDBContext>(options => options.UseMySql(
    mySqlConnectionStr,ServerVersion.AutoDetect(mySqlConnectionStr)
    ));

builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
