using Pets_And_Paws_Api.App.Application.DTOs.Requests.Auth;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Passwd;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Domain.Services;

public interface IAuthService
{
  Task<User> RegisterUser(RegisterUserDTO dto);
  Task<User> LoginUser(LoginUserDTO dto);
  Task SendRecoveryEmail(ForgetPasswordDTO dto);
  Task ResetPassword(ResetPasswordDTO dto);
}