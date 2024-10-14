using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class Bootstrap
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var dataset = configuration["DefaultDataset"] ?? throw new InvalidOperationException("DefaultDataset is not configured ");

    var connectionString = configuration.GetConnectionString(dataset)
      ?? throw new InvalidOperationException($"Connection string for {dataset} not found");

    services.AddDbContext<DatabaseContext>(options => {
      switch (dataset)
      {
        case "PostgresDefault":
          options.UseNpgsql(connectionString);
          break;
        case "SQLiteDefault":
          options.UseSqlite(connectionString);
          break;
        default:
          throw new NotSupportedException($"Database provider not supported: {dataset}");
      }
    });

    return services;
  }
}