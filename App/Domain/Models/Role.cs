using System.ComponentModel.DataAnnotations;
using Pets_And_Paws_Api.App.Domain.Models.Relationships;

namespace Pets_And_Paws_Api.App.Domain.Models;

public class RoleScope
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(20)]
  public string Name { get; set; } = string.Empty;

  [Required]
  [StringLength(150)]
  public string Description { get; set; } = string.Empty;

  public ICollection<User> Users { get; set; } = [];
  public ICollection<RoleScope> Scopes { get; set; } = [];
}