using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Factories.DbContextFactory;
using Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.UnitOfWork;

namespace Infrastructure;

public static class Bootstrap
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    AddDbContexts(services, configuration);

    services.AddTransient<IDbContextFactory, DbContextFactory>();
    services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    
    return services;
  }

  public static void AddDbContexts(IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgDbContext>(options => {
      options.UseNpgsql(configuration.GetConnectionString("PostgresConn"));
    });

    services.AddDbContext<SQLiteDbContext>(options => {
      options.UseSqlite(configuration.GetConnectionString("SQLiteConn"));
    });
  }
}