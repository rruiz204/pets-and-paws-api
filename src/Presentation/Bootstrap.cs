namespace Presentation;

public static class Bootstrap
{
  public static void AddPresentation(this IServiceCollection services)
  {
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddCors(options => {
      options.AddPolicy(name: "Local", configurePolicy: policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
      });
    });
  }
}