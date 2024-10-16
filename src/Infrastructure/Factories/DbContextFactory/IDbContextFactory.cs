using Infrastructure.Database.Contexts;

namespace Infrastructure.Factories.DbContextFactory;

public interface IDbContextFactory
{
  BaseDbContext GetDbContext();
}