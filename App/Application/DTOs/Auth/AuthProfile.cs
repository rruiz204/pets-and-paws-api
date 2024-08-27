using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Application.DTOs.Auth;

public class AuthProfile : Profile
{
  public AuthProfile()
  {
    CreateMap<RegisterUserDTO, User>();
    CreateMap<LoginUserDTO, User>();
  }
}