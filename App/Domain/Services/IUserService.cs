using Pets_And_Paws_Api.App.Application.DTOs.Entities;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IUserService
{
  Task<List<UserDTO>> GetAllAsync();
  Task<UserDTO?> GetAsync(int id);
}