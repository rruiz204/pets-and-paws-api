using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class UserRepository(DatabaseContext context) : GenericRepository<User>(context), IUserRepository
{
  public async Task<List<User>> ListAllUser()
  {
    return await dbSet
      .Include(u => u.Role).ToListAsync();
  }

  public async Task<User?> FindUserToAuth(string Email, string Name = "")
  {
    return await dbSet
      .Include(u => u.Role)
      .ThenInclude(r => r.Scopes)
      .ThenInclude(s => s.Scope)
      .Where(u => u.Email == Email || u.FirstName == Name)
      .FirstOrDefaultAsync();
  }
}