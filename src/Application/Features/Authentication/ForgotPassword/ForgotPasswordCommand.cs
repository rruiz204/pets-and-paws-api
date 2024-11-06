using MediatR;

namespace Application.Features.Authentication.ForgotPassword;

public class ForgotPasswordCommand : IRequest<ForgotPasswordResponse>
{
  public string Email { get; set; } = string.Empty;
}