using FluentValidation;
using System.Reflection;
using Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;
using Domain.Services;
using Domain.Settings;
using Application.Services.Jwt;
using Application.Services.Hasher;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Exceptions.Handlers;
using Application.Exceptions;

namespace Application;

public static class Bootstrap
{
  public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
  {
    // === Configurations
    services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

    // === Exceptions
    services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();
    services.AddTransient<IExceptionHandler, InvalidDataExceptionHandler>();

    // === Dependency Injection
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
      cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    });

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    services.AddScoped<PasswordHasher<User>>();
    services.AddScoped<IHasherService, HasherService>();

    services.AddScoped<IJwtService, JwtService>();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
      options.TokenValidationParameters = JwtService.GetParameters(configuration);
      options.Events = JwtService.GetEvents();
    });
  }
}