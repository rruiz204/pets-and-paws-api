using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Contexts;

public class SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : BaseDbContext(options)
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    ApplyConfigurations(modelBuilder);

    SetDefaultValueSQL(modelBuilder, "CreatedAt", "CURRENT_TIMESTAMP");
    SetDefaultValueSQL(modelBuilder, "UpdatedAt", "CURRENT_TIMESTAMP");
  }
}