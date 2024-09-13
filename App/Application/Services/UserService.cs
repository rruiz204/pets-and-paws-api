using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;
using AutoMapper;

namespace Pets_And_Paws_Api.App.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<UserDTO>> GetAllAsync()
  {
    return _mapper.Map<List<UserDTO>>(await _unitOfWork.Users.ListAllUser());
  }
}