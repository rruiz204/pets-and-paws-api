using Domain.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public class PgDbContext(DbContextOptions<PgDbContext> otpions) : DbContext(otpions)
{
  public DbSet<User> User { get; set; }
  public DbSet<Role> Role { get; set; }
  public DbSet<Claim> Claim { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    SetDefaultValueSQL(modelBuilder, "CreatedAt", "NOW()");
    SetDefaultValueSQL(modelBuilder, "UpdatedAt", "NOW()");

    modelBuilder.ApplyConfiguration(new RoleConfig());
    modelBuilder.ApplyConfiguration(new UserConfig());
  }

  private static void SetDefaultValueSQL(ModelBuilder builder, string property, string value)
  {
    var entities = builder.Model.GetEntityTypes()
      .Where(et => et.FindProperty(property) != null).ToList();

    entities.ForEach(e => builder.Entity(e.Name).Property(property).HasDefaultValueSql(value));
  }
}