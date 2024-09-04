using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Application.DTOs.Roles;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;

namespace Pets_And_Paws_Api.App.Application.Services;

public class RoleService(IUnitOfWork unitOfWork, IMapper mapper) : IRoleService
{
  private readonly IUnitOfWork _unitOfWork = unitOfWork;
  private readonly IMapper _mapper = mapper;

  public async Task<List<RoleResponseDTO>> GetAllAsync()
  {
    return _mapper.Map<List<RoleResponseDTO>>(await _unitOfWork.Roles.GetAllAsync());
  }
}