using Pets_And_Paws_Api.App.Application.DTOs.Users;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IUserService
{
  Task<List<UserResponseDTO>> GetAllAsync();
  Task<UserResponseDTO?> GetAsync(int id);
}