using System.Reflection;
using Application.Behaviours;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Domain.Services.HashPassword;
using Domain.Services.JsonWebTokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application;

public static class Bootstrap
{
  public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<PasswordHasher<User>>();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

    services.AddScoped<IHashPasswordService, HashPasswordService>();
    services.AddScoped<IJsonWebTokenService, JsonWebTokenService>();

    AddJwtAuthentication(services, configuration);

    return services;
  }

  private static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
  {
    var builder = services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    });

    builder.AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["JwtSettings:Issuer"],
        ValidAudience = configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtSettings:SecretKey")!))
      };
      options.Events = new JwtBearerEvents
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
    });
  }
}