using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<List<UserDTO>> GetAllAsync()
  {
    return await _unitOfWork.Users.GetAllUsersAsync();
  }

  public async Task<UserDTO?> GetAsync(int id) 
  {
    return await _unitOfWork.Users.GetUserAsync(id);
  }
}