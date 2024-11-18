using Domain.Repositories;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public async Task<TEntity> Create(TEntity entity)
  {
    await dbSet.AddAsync(entity);
    return entity;
  }
}