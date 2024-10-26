using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public class PgDbContext(DbContextOptions<PgDbContext> options) : DbContext(options)
{
  public DbSet<User> User { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    ApplyConfigurations(modelBuilder);

    SetDefaultValueSQL(modelBuilder, "CreatedAt", "NOW()");
    SetDefaultValueSQL(modelBuilder, "UpdatedAt", "NOW()");
  }

  private static void SetDefaultValueSQL(ModelBuilder builder, string property, string value)
  {
    var entities = builder.Model.GetEntityTypes()
      .Where(et => et.FindProperty(property) != null).ToList();

    entities.ForEach(et => builder.Entity(et.Name).Property(property).HasDefaultValueSql(value));
  }

  private static void ApplyConfigurations(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new UserConfig());
  }
}