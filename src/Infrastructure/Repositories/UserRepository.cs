using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(PgDbContext context) : GenericRepository<User>(context), IUserRepository
{
  public async Task<List<User>> GetUsers()
  {
    return await dbSet.ToListAsync();
  }

  public async Task<User?> FindWithRolesAndScopes(int userId)
  {
    return await dbSet.Where(u => u.Id == userId)
    .Include(u => u.UserRoles)
      .ThenInclude(ur => ur.Role)
        .ThenInclude(r => r.RoleScopes)
          .ThenInclude(rs => rs.Scope)
    .FirstOrDefaultAsync();
  }
}