using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Models;

public class ResetToken : BaseModel
{
  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; }

  [Required]
  public string Token { get; set; }

  [Required]
  public DateTime Expiration { get; set; }
}