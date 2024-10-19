using FluentValidation;

namespace Application.Features.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
  public CreateUserValidator()
  {
    RuleFor(c => c.FirstName)
      .NotEmpty()
      .MinimumLength(3)
      .MaximumLength(30);

    RuleFor(c => c.LastName)
      .NotEmpty()
      .MinimumLength(3)
      .MaximumLength(30);

    RuleFor(c => c.Email)
      .NotEmpty()
      .EmailAddress();

    RuleFor(c => c.Password)
      .NotEmpty()
      .MinimumLength(8)
      .MaximumLength(50);
  }
}