using Pets_And_Paws_Api.App.Application.DTOs.Entities;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IRoleService
{
  Task<List<RoleDTO>> GetAllAsync();
}