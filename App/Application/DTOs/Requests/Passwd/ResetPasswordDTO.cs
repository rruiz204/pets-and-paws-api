using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Application.DTOs.Requests.Passwd;

public class ResetPasswordDTO
{
  [Required]
  public string Token { get; set; } = string.Empty;

  [Required]
  [MinLength(8)]
  public string Password { get; set; } = string.Empty;
}