using AutoMapper;
using Pets_And_Paws_Api.App.Application.DTOs.Auth;
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
}