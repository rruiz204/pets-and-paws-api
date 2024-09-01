using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Application.DTOs.Passwd;

public class ForgetPasswordDTO
{
  [Required]
  [EmailAddress]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;
}