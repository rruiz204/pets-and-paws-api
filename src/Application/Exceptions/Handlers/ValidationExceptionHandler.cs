using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Exceptions.Handlers;

public class ValidationExceptionHandler : IExceptionHandler
{
  public bool CanHandle(Exception exception) => exception is ValidationException;

  public ErrorResponse Handle(HttpContext context, Exception exception)
  {
    var ex = (ValidationException)exception;
    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

    return new ErrorResponse
    {
      Title = "One or more validation errors occurred",
      Error = ex.Errors.First().ErrorMessage
    };
  }
}