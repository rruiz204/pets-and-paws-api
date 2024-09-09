using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Auth;

namespace Pets_And_Paws_Api.App.Application.DTOs.Profiles;

public class AuthProfile : Profile
{
  public AuthProfile()
  {
    CreateMap<RegisterUserDTO, User>();
  }
}