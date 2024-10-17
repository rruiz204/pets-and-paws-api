using Domain.Repositories;
using Infrastructure.Database.Contexts;
using Infrastructure.Factories.DbContextFactory;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
  where TEntity : class
{
  private readonly BaseDbContext _context;
  private readonly DbSet<TEntity> dbSet;

  public GenericRepository(IDbContextFactory factory)
  {
    _context = factory.GetDbContext();
    dbSet = _context.Set<TEntity>();
  }
}