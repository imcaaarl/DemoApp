//using AuthSvc.Authentication;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => {
    //options.AddDefaultPolicy(
    //    policy =>
    //    {
    //        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    //    }
    //    );
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:3003")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
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
app.UseCors("AllowOrigin");
app.Use((context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
    return next.Invoke();
});
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();