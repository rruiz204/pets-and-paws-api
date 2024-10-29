using FluentValidation;
using System.Reflection;
using Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using Domain.Services;
using Domain.Settings;
using Application.Services;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application;

public static class Bootstrap
{
  public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
  {
    // === Configurations
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

    // === Dependency Injection
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
      cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    });

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    services.AddScoped<PasswordHasher<User>>();
    services.AddScoped<IPasswordHasherService, PasswordHasherService>();

    services.AddScoped<IJwtService, JwtService>();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
      options.TokenValidationParameters = JwtService.GetParameters(configuration);
      options.Events = JwtService.GetEvents();
    });
  }
}