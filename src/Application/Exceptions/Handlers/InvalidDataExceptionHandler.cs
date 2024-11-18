using System.Net;
using Microsoft.AspNetCore.Http;

namespace Application.Exceptions.Handlers;

public class InvalidDataExceptionHandler : IExceptionHandler
{
  public bool CanHandle(Exception exception) => exception is InvalidDataException;

  public ErrorResponse Handle(HttpContext context, Exception exception)
  {
    var ex = (InvalidDataException)exception;
    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

    return new ErrorResponse
    {
      Title = "One or more validation errors occurred",
      Message = ex.Message
    };
  }
}