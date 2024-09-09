using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Application.DTOs.Requests.Auth;

public class LoginUserDTO
{
  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;
  
  [Required]
  [MinLength(8)]
  public string Password { get; set; } = string.Empty;
}