using FluentValidation;
using System.Reflection;
using Application.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrap
{
  public static void AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(cfg => {
      cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
      cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    });

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
  }
}