using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ScopeRepository(PgDbContext context) : GenericRepository<Scope>(context), IScopeRepository
{
  public async Task<List<Scope>> GetAllScopes()
  {
    return await dbSet.ToListAsync();
  }
}