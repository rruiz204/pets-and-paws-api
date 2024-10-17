using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrap
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IHashPasswordService, HashPasswordService>();
    return services;
  }
}