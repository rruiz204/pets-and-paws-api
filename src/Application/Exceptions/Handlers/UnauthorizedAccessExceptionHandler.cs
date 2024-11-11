using System.Net;
using Microsoft.AspNetCore.Http;

namespace Application.Exceptions.Handlers;

public class UnauthorizedAccessExceptionHandler : IExceptionHandler
{
  public bool CanHandle(Exception exception) => exception is UnauthorizedAccessException;

  public ErrorResponse Handle(HttpContext context, Exception exception)
  {
    var ex = (UnauthorizedAccessException)exception;
    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

    return new ErrorResponse
    {
      Title = "One or more validation errors occurred",
      Message = ex.Message
    };
  }
}