using System.ComponentModel.DataAnnotations;

namespace Pets_And_Paws_Api.App.Application.DTOs.Users;

public class UserResponseDTO
{
  public int Id { get; set; }

  public string FullName { get; set; } = string.Empty;
}
