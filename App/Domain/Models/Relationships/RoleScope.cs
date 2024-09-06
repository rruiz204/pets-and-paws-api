namespace Pets_And_Paws_Api.App.Domain.Models.Relationships;

public class RoleScope
{
  public int RoleId  { get; set; }
  public Role Role { get; set; } = new();

  public int PermissionId { get; set; }
  public Scope Scope { get; set; } = new();
}