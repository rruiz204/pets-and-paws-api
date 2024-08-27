using Pets_And_Paws_Api.App.Application.DTOs.Auth;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IAuthService
{
  Task<User> RegisterUser(RegisterUserDTO dto);
  Task<User> LoginUser(LoginUserDTO dto);
}