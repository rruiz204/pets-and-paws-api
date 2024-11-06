namespace Domain.Entities.Relations;

public class RoleScope
{
  public int RoleId { get; set; }
  public Role Role { get; set; } = null!;

  public int ScopeId { get; set; }
  public Scope Scope { get; set; } = null!;
}