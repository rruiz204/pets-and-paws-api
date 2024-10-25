using Infrastructure.Database.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database.Factory;

public class DbContextFactory(IServiceProvider serviceProvider, IConfiguration configuration) : IDbContextFactory
{
  private readonly IServiceProvider _serviceProvider = serviceProvider;
  private readonly IConfiguration _configuration = configuration;

  public BaseDbContext GetDbContext()
  {
    var defaultConnection = _configuration["DatabaseSettings:DefaultConnection"]
      ?? throw new InvalidDataException("'DefaultConnection' is missing or invalid");

    if (defaultConnection == "Postgres") return _serviceProvider.GetRequiredService<PgDbContext>();
    if (defaultConnection == "SQLite") return _serviceProvider.GetRequiredService<SQLiteDbContext>();

    throw new NotSupportedException("The 'DefaultConnection' is not supported");
  }
}