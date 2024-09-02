using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;

namespace Pets_And_Paws_Api.App.Application.DTOs.Users;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserResponseDTO>()
      .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
  }
}