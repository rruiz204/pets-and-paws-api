using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Presentation;

public static class Bootstrap
{
  public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
  {
    // === Dependency Injection
    services.AddControllers();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // === Rate Limiting
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

    // === CORS
    services.AddCors(options =>
    {
      options.AddPolicy(name: "Local", configurePolicy: policy =>
      {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
      });
    });
  }
}