using Pets_And_Paws_Api.App.DTO.Authentication;
using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.Services.Interfaces;

public interface IAuthService
{
  Task<User> RegisterUser(RegisterUserDTO dto);
  Task<User> LoginUser(LoginUserDTO dto);
}