using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database.Context;
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

    services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    return services;
  }
}