using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
  public DbSet<User> User { get; set; }
  public DbSet<ResetToken> ResetTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}