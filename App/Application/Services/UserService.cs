using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<UserDTO>> GetAllAsync()
  {
    return await _unitOfWork.Users.GetAllUsersAsync();
  }

  public async Task<UserDTO?> GetAsync(int id) 
  {
    return _mapper.Map<UserDTO>(await _unitOfWork.Users.GetAsync(id));
  }
}