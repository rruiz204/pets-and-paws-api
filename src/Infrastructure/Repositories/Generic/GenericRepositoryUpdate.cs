using Domain.Repositories;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public async Task Update(TEntity entity)
  {
    dbSet.Update(entity);
    await _context.SaveChangesAsync();
  }
}