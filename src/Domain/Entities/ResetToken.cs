using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ResetToken
{
  [Key]
  public int Id  { get; set; }

  [Required]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Token { get; set; } = string.Empty;

  [Required]
  public DateTime Expiration { get; set; }
}