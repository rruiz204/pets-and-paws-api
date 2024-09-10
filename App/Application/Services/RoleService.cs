using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Application.Services;

public class RoleService(IUnitOfWork unitOfWork) : IRoleService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<List<Role>> GetAllAsync()
  {
    return await _unitOfWork.Roles.GetAllRolesAsync();
  }
}