using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Configuration;
using Pets_And_Paws_Api.App.Database;
using Pets_And_Paws_Api.App.Repositories;
using Pets_And_Paws_Api.App.Repositories.Interfaces;
using Pets_And_Paws_Api.App.Services;
using Pets_And_Paws_Api.App.Services.Interfaces;
using Pets_And_Paws_Api.App.Utilities;
using Pets_And_Paws_Api.App.Utilities.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();

// Database Context
builder.Services.AddDbContext<DatabaseContext>(opts => 
    opts.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

// Services
builder.Services.AddScoped<IAuthService, AuthService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IResetTokenRepository, ResetTokenRepository>();

// Utilities
builder.Services.AddScoped<IEncrypt, Encrypt>();
builder.Services.AddScoped<ITokens, Tokens>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Authentication & Authorization
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/* app.UseAuthentication();
app.UseAuthorization(); */
app.MapControllers();
app.Run();