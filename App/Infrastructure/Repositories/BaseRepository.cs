using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Domain.Repositories;
using Pets_And_Paws_Api.App.Infrastructure.Database;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class BaseRepository<TEntity>(DatabaseContext context) : IBaseRepository<TEntity> where TEntity : class
{
  protected readonly DatabaseContext _context = context;
  protected readonly DbSet<TEntity> dbSet = context.Set<TEntity>();

  public async Task<List<TEntity>> GetAllAsync() => await dbSet.ToListAsync();

  public async Task<TEntity?> GetAsync(int id) => await dbSet.FindAsync(id);

  public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
  {
    return await dbSet.Where(predicate).ToListAsync();
  }

  public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate)
  {
    return await dbSet.Where(predicate).FirstOrDefaultAsync();
  }

  public async Task<TEntity> CreateAsync(TEntity entity)
  {
    await dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task DeleteAsync(TEntity entity)
  {
    dbSet.Remove(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<TEntity> UpdateAsync(TEntity entity)
  {
    dbSet.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}