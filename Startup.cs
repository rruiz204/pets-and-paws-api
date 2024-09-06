using Microsoft.EntityFrameworkCore;
using Pets_And_Paws_Api.App.Application.Services;
using Pets_And_Paws_Api.App.Domain.Services;
using Pets_And_Paws_Api.App.Domain.Utilities;
using Pets_And_Paws_Api.App.Infrastructure.Configuration;
using Pets_And_Paws_Api.App.Infrastructure.Database;
using Pets_And_Paws_Api.App.Infrastructure.UnitOfWork;
using Pets_And_Paws_Api.App.Infrastructure.Utilities;

namespace Pets_And_Paws_Api;

public class Startup(IConfiguration config)
{
  public IConfiguration Config { get; } = config;

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();

    services.AddAutoMapper(typeof(Startup));
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    ConfigureUtilities(services);
    ConfigureDbContext(services);
    ConfigureExtensions(services);
    ConfigureAppServices(services);
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
  }

  private void ConfigureDbContext(IServiceCollection services)
  {
    services.AddDbContext<DatabaseContext>(opts => opts.UseNpgsql(Config.GetConnectionString("PostgreSQL")));
  }

  private static void ConfigureAppServices(IServiceCollection services)
  {
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IRoleService, RoleService>();
  }

  private static void ConfigureUtilities(IServiceCollection services)
  {
    services.AddScoped<IEncrypt, Encrypt>();
    services.AddScoped<ITokens, Tokens>();
  }

  private void ConfigureExtensions(IServiceCollection services)
  {
    services.AddJwtAuthentication(Config);
  }
}