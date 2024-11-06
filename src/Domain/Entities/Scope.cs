using System.ComponentModel.DataAnnotations;
using Domain.Entities.Relations;

namespace Domain.Entities;

public class Scope
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Description { get; set; } = string.Empty;

  public List<RoleScope> RoleScopes { get; set; } = [];
}