using Presentation.Filters;

namespace Presentation;

public static class Bootstrap
{
  public static void AddPresentation(this IServiceCollection services)
  {
    services.AddControllers(options => {
      options.Filters.Add<ResponseFormatterFilter>();
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddCors(options => {
      options.AddPolicy(name: "Local", configurePolicy: policy => {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
      });
    });
  }
}