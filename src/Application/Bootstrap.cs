using FluentValidation;
using System.Reflection;
using Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Domain.Services.Jwt;
using Application.Services.Jwt;
using Domain.Services.Hasher;
using Application.Services.Hasher;

using Domain.Services.Policy;
using Application.Services.Policy;
using Application.Policies;

using Application.Exceptions;
using Application.Exceptions.Handlers;

namespace Application;

public static class Bootstrap
{
  public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
  {
    var jwtSettings = configuration.GetSection("JwtSettings");
    services.Configure<JwtSettings>(jwtSettings);

    services.AddScoped<IHasherService, HasherService>();
    services.AddScoped<IJwtService, JwtService>();
    services.AddScoped<IPolicyService, PolicyService>();

    services.AddScoped<PasswordHasher<User>>();

    AddVitalServices(services);
    AddExceptionHandlers(services);
    AddJwtAuthentication(services, jwtSettings.Get<JwtSettings>()!);
    AddAuthorizationPolicies(services);
  }

  private static void AddVitalServices(IServiceCollection services)
  {
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
      cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    });

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddHttpContextAccessor();
  }

  private static void AddExceptionHandlers(IServiceCollection services)
  {
    services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();
    services.AddTransient<IExceptionHandler, InvalidDataExceptionHandler>();
    services.AddTransient<IExceptionHandler, UnauthorizedAccessExceptionHandler>();
  }

  private static void AddJwtAuthentication(IServiceCollection services, JwtSettings settings)
  {
    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      var SecretKey = Encoding.UTF8.GetBytes(settings.SecretKey);
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = settings.Issuer,
        ValidAudience = settings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(SecretKey)
      };

      options.Events = new JwtBearerEvents
      {
        OnAuthenticationFailed = context => Task.FromException(new UnauthorizedAccessException("Invalid token")),
        OnChallenge = context => Task.FromException(new UnauthorizedAccessException("Token is missing")),
      };
    });
  }

  private static void AddAuthorizationPolicies(IServiceCollection services)
  {
    var provider = services.BuildServiceProvider();
    var service = provider.GetRequiredService<IPolicyService>();

    services.AddAuthorizationBuilder()
      .AddPolicy("Policy:PetsDirectory:Read",
        policy => policy.RequireAssertion(async context => await service.Handle(PetsDirectoryPolicy.Read.Roles, PetsDirectoryPolicy.Read.Scopes)))
      .AddPolicy("Policy:PetsDirectory:Create",
        policy => policy.RequireAssertion(async context => await service.Handle(PetsDirectoryPolicy.Create.Roles, PetsDirectoryPolicy.Create.Scopes)))
      .AddPolicy("Policy:PetsDirectory:Update",
        policy => policy.RequireAssertion(async context => await service.Handle(PetsDirectoryPolicy.Update.Roles, PetsDirectoryPolicy.Update.Scopes)))
      .AddPolicy("Policy:PetsDirectory:Delete",
        policy => policy.RequireAssertion(async context => await service.Handle(PetsDirectoryPolicy.Delete.Roles, PetsDirectoryPolicy.Delete.Scopes)));
  }
}