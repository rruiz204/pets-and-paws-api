using AutoMapper;
using Pets_And_Paws_Api.App.Models;

namespace Pets_And_Paws_Api.App.DTO.Authentication;

public class AuthProfile : Profile
{
  public AuthProfile()
  {
    CreateMap<RegisterUserDTO, User>();
    CreateMap<LoginUserDTO, User>();
  }
}