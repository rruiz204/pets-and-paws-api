using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Domain.Models;

public class Role : BaseModel
{
  [Required]
  [StringLength(20)]
  public string Name { get; set; } = string.Empty;
}