using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Database;
using Pets_And_Paws_Api.App.Repositories;
using Pets_And_Paws_Api.App.Repositories.Interfaces;

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

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

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