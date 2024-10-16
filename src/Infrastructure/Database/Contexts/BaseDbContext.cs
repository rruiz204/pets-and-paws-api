using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Contexts;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<User> User { get; set; }
}