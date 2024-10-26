namespace Presentation;

public static class Bootstrap
{
  public static void AddPresentation(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  }
}