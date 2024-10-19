using System.Reflection;
using Application.Behaviours;
using Application.Services;
using Domain.Entities;
using Domain.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Bootstrap
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IHashPasswordService, HashPasswordService>();
    services.AddScoped<PasswordHasher<User>>();

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    return services;
  }
}