namespace Application.Policies;

public class PetsDirectoryPolicy
{
  private static string[] BaseRoles { get; } = ["admin", "veterinarian"];
  private static string[] BaseScopes { get; } = ["global-access"];
  
  public class Read
  {
    public static string[] Roles { get; } = [.. BaseRoles];
    public static string[] Scopes { get; } = [.. BaseScopes, "pets-directory:read"];
  }

  public class Create
  {
    public static string[] Roles { get; } = [.. BaseRoles];
    public static string[] Scopes { get; } = [.. BaseScopes, "pets-directory:create"];
  }

  public class Update
  {
    public static string[] Roles { get; } = [.. BaseRoles];
    public static string[] Scopes { get; } = [.. BaseScopes, "pets-directory:update"];
  }

  public class Delete
  {
    public static string[] Roles { get; } = [.. BaseRoles];
    public static string[] Scopes { get; } = [.. BaseScopes, "pets-directory:delete"];
  }
}