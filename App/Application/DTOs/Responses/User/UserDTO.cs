namespace Pets_And_Paws_Api.App.Application.DTOs.Responses.User;

public class UserDTO
{
  public int Id { get; set; }
  public string FullName { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty;
}