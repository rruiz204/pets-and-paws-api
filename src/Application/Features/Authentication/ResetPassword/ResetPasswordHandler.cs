using Domain.Database;
using Domain.Services;
using MediatR;

namespace Application.Features.Authentication.ResetPassword;

public class ResetPasswordHandler(IUnitOfWork unitOfWork, IHasherService hasher) : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IHasherService _hasher = hasher;

  public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
  {
    using var transaction = await _unitOfWork.StartTransaction();
    try
    {
      var token = await _unitOfWork.ResetToken.Find(rt => rt.Token == request.Token && rt.Expiration >= DateTime.UtcNow)
        ?? throw new InvalidDataException("Password reset token is invalid or has expired.");

      var user = await _unitOfWork.User.Find(u => u.Email == token.Email)
        ?? throw new InvalidDataException("The user of this token does not exist.");

      user.Password = _hasher.Hash(request.NewPassword);

      _unitOfWork.ResetToken.Delete(token);
      await _unitOfWork.SaveChangesAsync();
      await transaction.Commit();

      return new ResetPasswordResponse
      {
        Message = "Password updated!"
      };
    }
    catch
    {
      await transaction.Rollback();
      throw;
    }
  }
}