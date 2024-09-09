using Pets_And_Paws_Api.App.Application.DTOs.Entities;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
  Task<List<UserDTO>> GetAllUsersAsync();
  Task<User?> FindToValidRegister(User user);
}