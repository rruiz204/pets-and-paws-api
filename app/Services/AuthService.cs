using AutoMapper;
using Pets_And_Paws_Api.App.DTO.Authentication;
using Pets_And_Paws_Api.App.Models;
using Pets_And_Paws_Api.App.Repositories.Interfaces;
using Pets_And_Paws_Api.App.Services.Interfaces;
using Pets_And_Paws_Api.App.Utilities.Interfaces;

namespace Pets_And_Paws_Api.App.Services;

public class AuthService(
  IUserRepository userRepository,
  IMapper mapper,
  IEncrypt encrypt
) : IAuthService
{
  private readonly IUserRepository _userRepository = userRepository;
  private readonly IMapper _mapper = mapper;
  private readonly IEncrypt _encrypt = encrypt;

  public async Task<User> RegisterUser(RegisterUserDTO dto)
  {
    User user = _mapper.Map<User>(dto);
    if (await _userRepository.FindUser(user) != null)
    {
      throw new ArgumentException("This credentials are not available");
    }
    dto.Password = _encrypt.Hash(dto.Password);
    return await _userRepository.CreateUser(user);
  }

  public async Task<User> LoginUser(LoginUserDTO dto)
  {
    User? existingUser = await _userRepository.FindUser(_mapper.Map<User>(dto));
    if (existingUser == null) throw new ArgumentException("This user does not exist");
    
    if(!_encrypt.Verify(existingUser.Password, dto.Password)) throw new ArgumentException("Invalid Credentials");
    return existingUser;
  }
}