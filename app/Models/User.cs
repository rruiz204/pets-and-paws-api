using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Models;

public class User : BaseModel
{
  [Required]
  [StringLength(50)]
  public string FirstName { get; set; }

  [Required]
  [StringLength(50)]
  public string LastName { get; set; }

  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; }

  [Required]
  [MinLength(8)]
  public string Password { get; set; }

  [Required]
  [StringLength(9)]
  public string PhoneNumber { get; set; }
}