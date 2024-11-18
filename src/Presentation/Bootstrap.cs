using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Presentation;

public static class Bootstrap
{
  public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
  {
    AddVitalServices(services);
    AddRateLimiter(services, configuration);
    AddCors(services);
  }

  private static void AddVitalServices(IServiceCollection services)
  {
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
  }

  private static void AddRateLimiter(IServiceCollection services, IConfiguration configuration)
  {
    services.AddRateLimiter(options =>
    {
      options.AddFixedWindowLimiter(policyName: "Fixed", options =>
      {
        options.PermitLimit = Convert.ToInt32(configuration["RateLimitingSettings:RequestLimit"]);
        options.Window = TimeSpan.FromMinutes(Convert.ToInt32(configuration["RateLimitingSettings:MinutesBlocked"]));
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
      });
    });
  }

  private static void AddCors(IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy(name: "Local", configurePolicy: policy =>
      {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
      });
    });
  }
}