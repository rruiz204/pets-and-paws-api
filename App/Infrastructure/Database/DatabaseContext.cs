using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database.Configuration;

namespace Pets_And_Paws_Api.App.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
  public DbSet<User> User { get; set; }
  public DbSet<Role> Role { get; set; }
  public DbSet<ResetToken> ResetToken { get; set; }
  public DbSet<Permission> Permission { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new RolePermissionConfig());
    }
}