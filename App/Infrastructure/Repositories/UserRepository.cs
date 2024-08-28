using System.Linq.Expressions;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Domain.Repositories;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class UserRepository(DatabaseContext context) : BaseRepository<User>(context), IUserRepository
{
  public async Task<User?> FindToValidRegister(User user)
  {
    Expression<Func<User, bool>> predicate = u => u.Email == user.Email || u.FirstName == user.FirstName;
    return await FindAsync(predicate);
  }
}