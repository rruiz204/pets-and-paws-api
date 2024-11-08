using MediatR;

namespace Application.Features.Authentication.ResetPassword;

public class ResetPasswordCommand : IRequest<ResetPasswordResponse>
{
  public string Token { get; set; } = string.Empty;
  public string NewPassword { get; set; } = string.Empty;
}