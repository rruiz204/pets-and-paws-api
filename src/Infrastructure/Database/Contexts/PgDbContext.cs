using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Contexts;

public class PgDbContext(DbContextOptions<PgDbContext> options) : BaseDbContext(options)
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}