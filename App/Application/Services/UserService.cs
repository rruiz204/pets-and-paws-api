using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Users;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<UserResponseDTO>> GetAllAsync()
  {
    return _mapper.Map<List<UserResponseDTO>>(await _unitOfWork.Users.GetAllAsync());
  }

  public async Task<UserResponseDTO?> GetAsync(int id) 
  {
    return _mapper.Map<UserResponseDTO>(await _unitOfWork.Users.GetAsync(id));
  }
}