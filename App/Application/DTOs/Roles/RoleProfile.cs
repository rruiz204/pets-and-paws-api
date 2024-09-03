using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Application.DTOs.Roles;

public class RoleProfile : Profile
{
  public RoleProfile()
  {
    CreateMap<Role, RoleResponseDTO>();
  }
}