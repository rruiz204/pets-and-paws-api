namespace Pets_And_Paws_Api.App.Application.DTOs.Entities;

public class AuthDTO(string token)
{
  public string Type { get; set; } = "Bearer";
  public string Token { get; set; } = token;
}