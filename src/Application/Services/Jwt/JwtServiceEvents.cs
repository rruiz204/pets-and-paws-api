using Application.Exceptions;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Jwt;

public partial class JwtService : IJwtService
{
  public static JwtBearerEvents GetEvents()
  {
    return new JwtBearerEvents
    {
      OnAuthenticationFailed = context =>
      {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new ErrorResponse
        {
          Title = "Unauthorized",
          Message = "Invalid token"
        });
      },
      OnChallenge = context =>
      {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new ErrorResponse
        {
          Title = "Unauthorized",
          Message = "Token is missing"
        });
      }
    };
  }
}