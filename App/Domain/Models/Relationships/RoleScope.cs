namespace Pets_And_Paws_Api.App.Domain.Models.Relationships;

public class RoleScope
{
  public int RoleId  { get; set; }
  public required Role Role { get; set; }

  public int PermissionId { get; set; }
  public required Scope Scope { get; set; }
}