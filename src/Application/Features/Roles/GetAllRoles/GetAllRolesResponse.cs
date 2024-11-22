using Application.Features.Roles.DTOs;

namespace Application.Features.Roles.GetAllRoles;

public class GetAllRolesResponse
{
  public List<RoleDTO> Roles { get; set; } = [];
  public List<ScopeDTO> Scopes { get; set; } = [];
}