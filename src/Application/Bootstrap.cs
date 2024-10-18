using Application.Services;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrap
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IHashPasswordService, HashPasswordService>();
    services.AddScoped<PasswordHasher<User>>();
    return services;
  }
}