using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Infrastructure.Configuration;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Application.Services;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Infrastructure.Utilities;
using Pets_And_Paws_Api.App.Domain.Utilities;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;
using Pets_And_Paws_Api.App.Presentation.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Controllers & Filters
builder.Services.AddControllers(options => {
  options.Filters.Add<LogicExceptionFilter>();
  options.Filters.Add<FormatResponseFilter>();
});

// Database Context
builder.Services.AddDbContext<DatabaseContext>(opts => 
    opts.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Utilities
builder.Services.AddScoped<IEncrypt, Encrypt>();
builder.Services.AddScoped<ITokens, Tokens>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Authentication & Authorization
builder.Services.EnableTokens(builder.Configuration);
builder.Services.EnablePolicies();

// CORS
builder.Services.EnableCors();

// Rate Limiter
builder.Services.EnableRateLimiter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRateLimiter();
app.UseCors("Develop");
app.Run();