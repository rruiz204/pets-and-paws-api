namespace Pets_And_Paws_Api.App.Domain.Models.Relationships;

public class RolePermission
{
  public int RoleId  { get; set; }
  public Role Role { get; set; }

  public int PermissionId { get; set; }
  public Permission Permission { get; set; }
}