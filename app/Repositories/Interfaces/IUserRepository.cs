using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.Repositories.Interfaces;

public interface IUserRepository
{
  Task<List<User>> ListUsers();
  Task<User> GetUser(int id);
  Task<User> CreateUser(User user);
  Task<User> UpdateUser(User user);
}