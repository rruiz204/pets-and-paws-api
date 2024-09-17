namespace Pets_And_Paws_Api.App.Infrastructure.Configuration;

public static class CORS
{
  public static void EnableCors(this IServiceCollection services)
  {
    services.AddCors(options => 
    {
      options.AddPolicy(name: "Develop", configurePolicy: policy =>
      {
        policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
    });
  }
}