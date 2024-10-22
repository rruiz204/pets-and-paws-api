using Infrastructure.Database.Contexts;

namespace Infrastructure.Database.Factory;

public interface IDbContextFactory
{
  BaseDbContext GetDbContext();
}