using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database.Configuration;
using Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

namespace Pets_And_Paws_Api.App.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : DbContext(options)
{
  private readonly IConfiguration _config = config;
  public DbSet<User> User { get; set; }
  public DbSet<Role> Role { get; set; }
  public DbSet<ResetToken> ResetToken { get; set; }
  public DbSet<Scope> Scopes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    foreach (var entity in modelBuilder.Model.GetEntityTypes()
      .Where(t => t.ClrType.IsAssignableTo(typeof(BaseModel))))
    {
      modelBuilder.Entity(entity.Name)
        .Property("CreatedAt")
        .HasDefaultValueSql("NOW()")
        .ValueGeneratedOnAdd();

      modelBuilder.Entity(entity.Name)
        .Property("UpdatedAt")
        .HasDefaultValueSql("NOW()")
        .ValueGeneratedOnAdd();
    }

    // Seeders
    modelBuilder.ApplyConfiguration(new ScopeSeed());
    modelBuilder.ApplyConfiguration(new RoleSeed());
    modelBuilder.ApplyConfiguration(new UserSeed(_config));

    // Relationships
    modelBuilder.ApplyConfiguration(new RoleScopeConfig());
  }
}