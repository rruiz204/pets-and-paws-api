using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Contexts;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<User> User { get; set; }
  
  protected static void SetDefaultValueSQL(ModelBuilder builder, string property, string value)
  {
    var entities = builder.Model.GetEntityTypes()
      .Where(et => et.FindProperty(property) != null).ToList();
    
    entities.ForEach(et => builder.Entity(et.Name).Property(property).HasDefaultValueSql(value));
  }
}