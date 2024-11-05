using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  [StringLength(50)]
  public string LastName { get; set; } = string.Empty;

  [Required]
  [MaxLength(150)]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Password { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public List<Role> Roles { get; set; } = [];
}