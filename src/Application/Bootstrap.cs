using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrap
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    return services;
  }
}