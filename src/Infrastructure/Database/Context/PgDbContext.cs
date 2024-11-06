using Domain.Entities;
using Domain.Entities.Relations;
using Domain.Services;
using Infrastructure.Database.Configurations;
using Infrastructure.Database.Configurations.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Context;

public class PgDbContext(DbContextOptions<PgDbContext> options, IConfiguration configuration) : DbContext(options)
{
  private readonly IConfiguration _configuration = configuration;
  public DbSet<User> User { get; set; }
  public DbSet<UserRole> UserRole { get; set; }
  public DbSet<Role> Role { get; set; }
  public DbSet<Scope> Scope { get; set; }
  public DbSet<RoleScope> RoleScope { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    SetDefaultValueSQL(modelBuilder, "CreatedAt", "NOW()");
    SetDefaultValueSQL(modelBuilder, "UpdatedAt", "NOW()");

    modelBuilder.ApplyConfiguration(new UserConfig(_configuration));
    modelBuilder.ApplyConfiguration(new RoleConfig());
    modelBuilder.ApplyConfiguration(new UserRoleConfig());
    modelBuilder.ApplyConfiguration(new RoleScopeConfig());
  }

  private static void SetDefaultValueSQL(ModelBuilder builder, string property, string value)
  {
    var entities = builder.Model.GetEntityTypes()
      .Where(et => et.FindProperty(property) != null).ToList();

    entities.ForEach(e => builder.Entity(e.Name).Property(property).HasDefaultValueSql(value));
  }
}