using System.Linq.Expressions;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Pets_And_Paws_Api.App.Infrastructure.Repositories;

public class UserRepository(DatabaseContext context, IMapper mapper) : BaseRepository<User>(context), IUserRepository
{
  public async Task<User?> GetUserWithScopes(int id)
  {
    return await dbSet
      .Include(user => user.Role)
      .ThenInclude(role => role.Scopes)
      .Where(user => user.Id == id).FirstOrDefaultAsync();
  }

  public async Task<List<UserDTO>> GetAllUsersAsync()
  {
    return await dbSet.Include(user => user.Role)
      .ProjectTo<UserDTO>(mapper.ConfigurationProvider).ToListAsync();
  }

  public async Task<List<UserDTO>> FindAllUserAsync(Expression<Func<User, bool>> predicate)
  {
    return await dbSet.Where(predicate)
      .ProjectTo<UserDTO>(mapper.ConfigurationProvider).ToListAsync();
  }

  public async Task<UserDTO?> GetUserAsync(int id)
  {
    return await dbSet.Include(user => user.Role).Where(u => u.Id == id)
      .ProjectTo<UserDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
  }

  public async Task<User?> FindToValidRegister(User user)
  {
    Expression<Func<User, bool>> predicate = u => u.Email == user.Email || u.FirstName == user.FirstName;
    return await dbSet.Where(predicate).FirstOrDefaultAsync();
  }
}