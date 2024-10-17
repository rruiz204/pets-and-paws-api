using System.Linq.Expressions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity> : IGenericRepository<TEntity>
{
  public async Task<TEntity?> Find(int id)
  {
    return await dbSet.FindAsync(id);
  }

  public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
  {
    return await dbSet.Where(predicate).FirstOrDefaultAsync();
  }
}