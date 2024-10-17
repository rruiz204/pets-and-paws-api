using Domain.Repositories;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public async Task Create(TEntity entity)
  {
    await dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
  }
}