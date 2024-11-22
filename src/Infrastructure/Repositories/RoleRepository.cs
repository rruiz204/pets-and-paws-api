using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoleRepository(PgDbContext context) : GenericRepository<Role>(context), IRoleRepository
{
  public async Task<List<Role>> GetAllRoles()
  {
    return await dbSet.Include(r => r.RoleScopes)
      .ThenInclude(rs => rs.Scope).ToListAsync();
  }
}