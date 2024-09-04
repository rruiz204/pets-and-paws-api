using Pets_And_Paws_Api.App.Application.DTOs.Roles;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IRoleService
{
  Task<List<RoleResponseDTO>> GetAllAsync();
}