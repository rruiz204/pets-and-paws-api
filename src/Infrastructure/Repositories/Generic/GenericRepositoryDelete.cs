using Domain.Repositories;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public void Delete(TEntity entity)
  {
    dbSet.Remove(entity);
  }
}