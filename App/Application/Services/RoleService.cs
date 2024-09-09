using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Entities;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class RoleService(IUnitOfWork unitOfWork, IMapper mapper) : IRoleService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<RoleDTO>> GetAllAsync()
  {
    return _mapper.Map<List<RoleDTO>>(await _unitOfWork.Roles.GetAllAsync());
  }
}