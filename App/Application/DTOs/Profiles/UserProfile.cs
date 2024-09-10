using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Application.DTOs.Responses.User;

namespace Pets_And_Paws_Api.App.Application.DTOs.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDTO>()
      .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => 
        !string.IsNullOrEmpty(src.LastName) ? $"{src.FirstName} {src.LastName}" : src.FirstName))
      .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
  }
}