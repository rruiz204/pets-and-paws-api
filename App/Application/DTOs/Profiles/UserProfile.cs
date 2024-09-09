using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Application.DTOs.Entities;

namespace Pets_And_Paws_Api.App.Application.DTOs.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDTO>();
  }
}