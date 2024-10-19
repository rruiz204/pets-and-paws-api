using Domain.Repositories;
using Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity>(BaseDbContext context) : IGenericRepository<TEntity>
  where TEntity : class
{
  protected readonly BaseDbContext _context = context;
  protected readonly DbSet<TEntity> dbSet = context.Set<TEntity>();
}