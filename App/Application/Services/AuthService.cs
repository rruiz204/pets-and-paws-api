using AutoMapper;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Auth;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Passwd;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Domain.Utilities;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class AuthService(
  IUnitOfWork unitOfWork,
  IMapper mapper,
  IEncrypt encrypt
) : IAuthService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;
  private readonly IEncrypt _encrypt = encrypt;

  public async Task<User> RegisterUser(RegisterUserDTO dto)
  {
    User user = _mapper.Map<User>(dto);
    if (await _unitOfWork.Users.FindToValidRegister(user) != null)
    {
      throw new ArgumentException("This credentials are not available");
    }
    user.Password = _encrypt.Hash(dto.Password);
    return await _unitOfWork.Users.CreateAsync(user);
  }

  public async Task<User> LoginUser(LoginUserDTO dto)
  {
    User? existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email)
      ?? throw new ArgumentException("This user does not exist");
    if (!_encrypt.Verify(existingUser.Password, dto.Password))
    {
      throw new ArgumentException("Invalid Credentials");
    }
    return existingUser;
  }

  public async Task SendRecoveryEmail(ForgetPasswordDTO dto)
  {
    User? existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email)
      ?? throw new ArgumentException("This user does not exist");
    await _unitOfWork.Tokens.CreateResetToken(_mapper.Map<ResetToken>(dto));
  }

  public async Task ResetPassword(ResetPasswordDTO dto)
  {
    ResetToken? validToken = await _unitOfWork.Tokens.FindValidToken(dto.Token)
      ?? throw new ArgumentException("Invalid or expired token");
    
    User? existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == validToken.Email)
      ?? throw new ArgumentException("This user does not exist");
    
    existingUser.Password = _encrypt.Hash(dto.Password);
    await _unitOfWork.Users.UpdateAsync(existingUser);
    await _unitOfWork.Tokens.DeleteResetToken(validToken);
    }
}