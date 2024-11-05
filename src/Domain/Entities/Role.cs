using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Role
{
  [Key]
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Description { get; set; } = string.Empty;

  public List<Claim> Claims { get; set; } = [];
  public List<User> Users { get; set; } = [];
}