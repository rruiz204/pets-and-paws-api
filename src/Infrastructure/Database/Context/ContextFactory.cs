using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Context;

public class ContextFactory : IDesignTimeDbContextFactory<PgDbContext>
{
  public PgDbContext CreateDbContext(string[] args)
  {
    var currentDirectory = Directory.GetCurrentDirectory();
    var presentationPath = Path.GetFullPath(Path.Combine(currentDirectory, "..", "Presentation"));

    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(presentationPath)
      .AddJsonFile("appsettings.json", optional: false).Build();

    var builder = new DbContextOptionsBuilder<PgDbContext>();
    builder.UseNpgsql(configuration["DatabaseSettings:Connections:Postgres"]);
    return new PgDbContext(builder.Options);
  }
}