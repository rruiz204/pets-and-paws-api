using AutoMapper;
using Pets_And_Paws_Api.App.Domain.Models;
using Pets_And_Paws_Api.App.Application.DTOs.Requests.Passwd;

namespace Pets_And_Paws_Api.App.Application.DTOs.Profiles;

public class PasswdProfile : Profile
{
  public PasswdProfile()
  {
    CreateMap<ForgetPasswordDTO, ResetToken>()
      .ForMember(dest => dest.Token, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
      .ForMember(dest => dest.Expiration, opt => opt.MapFrom(src => DateTime.UtcNow.AddHours(1)));
  }
}