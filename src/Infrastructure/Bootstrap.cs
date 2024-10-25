using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database.Factory;
using Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.UnitOfWork;

namespace Infrastructure;

public static class Bootstrap
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgDbContext>(options => {
      options.UseNpgsql(configuration["DatabaseSettings:Connections:Postgres"]);
    });

    services.AddDbContext<SQLiteDbContext>(options => {
      options.UseSqlite(configuration["DatabaseSettings:Connections:SQLite"]);
    });

    services.AddTransient<IDbContextFactory, DbContextFactory>();
    services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    
    return services;
  }
}