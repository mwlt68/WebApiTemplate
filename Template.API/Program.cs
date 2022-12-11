using Business.Mapping;
using Core.Extensions;
using Core.Utilities.Cache.Base;
using Core.Utilities.Cache.MemoryCache;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstracts;
using DataAccess.Concreate.Contexts;
using DataAccess.Concreate.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsSection);

var cacheSettingsSection = builder.Configuration.GetSection("CacheSettings");
builder.Services.Configure<CacheSettings>(cacheSettingsSection);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllers();
builder.Services.AddCustomSwaggerGen();

var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
builder.Services.AddCustomJwtToken(jwtSettings);

builder.Services.AddCustomAutoMapper(new GeneralMapping());

builder.Services.AddMemoryCache();

builder.Services.AddTransient<ICacheService, MemoryCacheService>();

builder.Services.AddSingleton<IJwtService, JwtService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<Business.Abstract.IAuthenticationService, Business.Concreate.AuthenticationService>();

builder.Services.AddEndpointsApiExplorer();

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
