namespace Domain.Services.Policy;

public interface IPolicyService
{
  Task<bool> Handle(string[] roles, string[] scopes);
}