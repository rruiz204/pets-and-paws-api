using Domain.Repositories;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Generic;

public partial class GenericRepository<TEntity>(PgDbContext context) : IGenericRepository<TEntity>
  where TEntity : class
{
  protected readonly PgDbContext _context = context;
  protected readonly DbSet<TEntity> dbSet = context.Set<TEntity>();
}