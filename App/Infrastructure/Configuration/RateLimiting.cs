using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

namespace Pets_And_Paws_Api.App.Infrastructure.Configuration;

public static class RateLimiting
{
  public static void EnableRateLimiter(this IServiceCollection services)
  {
    services.AddRateLimiter(options => 
    {
      options.AddFixedWindowLimiter(policyName: "fixed", opts => {
        opts.PermitLimit = 5;
        opts.Window = TimeSpan.FromMinutes(1);
        opts.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        opts.QueueLimit = 2;
      });
    });
  }
}