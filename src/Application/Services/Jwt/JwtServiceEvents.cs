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
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new { message = "Invalid token" });
      },
      OnChallenge = context =>
      {
        context.HandleResponse();
        context.Response.StatusCode = 401;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(new { message = "Token is missing" });
      }
    };
  }
}