using System.Linq.Expressions;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
  Task<List<UserDTO>> GetAllUsersAsync();
  Task<List<UserDTO>> FindAllUserAsync(Expression<Func<User, bool>> predicate);
  Task<UserDTO?> GetUserAsync(int id);
  Task<User?> GetUserWithScopes(int id);
  Task<User?> FindToValidRegister(User user);
}