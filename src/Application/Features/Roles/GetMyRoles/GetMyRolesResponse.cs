namespace Application.Features.Roles.GetMyRoles;

public class GetMyRolesResponse
{
  public List<string> Roles { get; set; } = [];
  public List<string> Scopes { get; set; } = [];
}