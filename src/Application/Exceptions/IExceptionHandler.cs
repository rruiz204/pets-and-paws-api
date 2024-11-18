using Microsoft.AspNetCore.Http;

namespace Application.Exceptions;

public interface IExceptionHandler
{
  bool CanHandle(Exception exception);
  ErrorResponse Handle(HttpContext context, Exception exception);
}