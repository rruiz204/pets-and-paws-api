using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Domain.Models;

public class User : BaseModel
{
  [Required]
  [StringLength(50)]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  [StringLength(50)]
  public string LastName { get; set; } = string.Empty;

  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;

  [Required]
  [MinLength(8)]
  public string Password { get; set; } = string.Empty;

  [Required]
  [StringLength(9)]
  public string PhoneNumber { get; set; } = string.Empty;
}