using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database.Configuration;
using Pets_And_Paws_Api.App.Infrastructure.Database.Seeders;

namespace Pets_And_Paws_Api.App.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
  public DbSet<User> User { get; set; }
  public DbSet<Role> Role { get; set; }
  public DbSet<ResetToken> ResetToken { get; set; }
  public DbSet<Scope> Scopes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Relationships
        modelBuilder.ApplyConfiguration(new RoleScopeConfig());

        // Seeders
        modelBuilder.ApplyConfiguration(new PermissionSeed());
    }
}