using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Domain.Models;

public class ResetToken : BaseModel
{
  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Token { get; set; } = string.Empty;

  [Required]
  public DateTime Expiration { get; set; }
}