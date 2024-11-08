using Domain.Database;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authentication.ForgotPassword;

public class ForgotPasswordHandler(IUnitOfWork unitOfWork) : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
  {
    if (await _unitOfWork.User.Find(u => u.Email == request.Email) == null)
      throw new InvalidDataException($"User with this email does not exist.");

    if (await _unitOfWork.ResetToken.Find(rt => rt.Email == request.Email && rt.Expiration >= DateTime.UtcNow) != null)
      throw new InvalidDataException($"There is an active token with this email");

    var token = new ResetToken
    {
      Email = request.Email,
      Token = Guid.NewGuid().ToString(),
      Expiration = DateTime.UtcNow.AddMinutes(10)
    };

    await _unitOfWork.ResetToken.Create(token);
    await _unitOfWork.SaveChangesAsync();
    
    return new ForgotPasswordResponse {
      Message = "Reset token created!"
    };
  }
}