using FluentValidation;

namespace Application.Features.Authentication.LoginUser;

public class LoginUserValidation : AbstractValidator<LoginUserCommand>
{
  public LoginUserValidation()
  {
    RuleFor(command => command.Email)
      .NotEmpty().EmailAddress()
      .MaximumLength(60);

    RuleFor(command => command.Password)
      .NotEmpty()
      .MinimumLength(8).MaximumLength(50);
  }
}