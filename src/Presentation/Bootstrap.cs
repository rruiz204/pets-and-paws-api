namespace Presentation;

public static class Bootstrap
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    return services;
  }
}