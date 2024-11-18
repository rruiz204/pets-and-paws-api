using FluentValidation;

namespace Application.Features.Authentication.ForgotPassword;

public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordCommand>
{
  public ForgotPasswordValidation()
  {
    RuleFor(command => command.Email)
      .NotEmpty().EmailAddress()
      .MaximumLength(150);
  }
}