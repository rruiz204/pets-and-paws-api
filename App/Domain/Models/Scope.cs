using System.ComponentModel.DataAnnotations;
using Pets_And_Paws_Api.App.Domain.Models.Relationships;

namespace Pets_And_Paws_Api.App.Domain.Models;

public class Scope : BaseModel
{
  [Required]
  [MinLength(10)]
  [MaxLength(30)]
  public string Name { get; set; } = string.Empty;
  public ICollection<RoleScope> Roles { get; set; }
}