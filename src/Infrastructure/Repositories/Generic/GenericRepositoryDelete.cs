using Domain.Repositories;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public async Task Delete(TEntity entity)
  {
    dbSet.Remove(entity);
    await _context.SaveChangesAsync();
  }
}