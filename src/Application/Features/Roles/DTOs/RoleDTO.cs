namespace Application.Features.Roles.DTOs;

public class RoleDTO
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public List<int> Scopes { get; set; } = [];
}