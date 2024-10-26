using Domain.Database;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Bootstrap
{
  public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgDbContext>(options => {
      options.UseNpgsql(configuration["DatabaseSettings:Connections:Postgres"]);
    });

    services.AddScoped<IUnitOfWork, UnitOfWork>();
  }
}