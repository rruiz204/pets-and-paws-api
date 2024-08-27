using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IUserRepository
{
  Task<List<User>> ListUsers();
  Task<User> GetUser(int id);
  Task<User> CreateUser(User user);
  Task<User> UpdateUser(User user);
  Task<User?> FindUser(User user);
}