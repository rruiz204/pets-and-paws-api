using Infrastructure.Database.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Factories.DbContextFactory;

public class DbContextFactory(IServiceProvider serviceProvider, IConfiguration configuration) : IDbContextFactory
{
  private readonly IServiceProvider _serviceProvider = serviceProvider;
  private readonly IConfiguration _configuration = configuration;

  public BaseDbContext GetDbContext()
  {
    var defaultConnection = _configuration["DatabaseSettings:DefaultConnection"]
      ?? throw new InvalidDataException("");

    if (defaultConnection == "PostgresConn") return _serviceProvider.GetRequiredService<PgDbContext>();
    if (defaultConnection == "SQLiteConn") return _serviceProvider.GetRequiredService<SQLiteDbContext>();

    throw new NotSupportedException("Invalid");
  }
}