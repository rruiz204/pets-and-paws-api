namespace Pets_And_Paws_Api.App.Infrastructure.Configuration;

public static class AuthPolicies
{
  public static void AddPolicies(this IServiceCollection services)
  {
    services.AddAuthorizationBuilder()
      .AddPolicy("user:read", policy => policy.RequireClaim("scopes", "user:read"));
  }
}