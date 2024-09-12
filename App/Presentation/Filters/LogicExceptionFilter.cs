using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pets_And_Paws_Api.App.Domain.Exceptions;

namespace Pets_And_Paws_Api.App.Presentation.Filters;

public class LogicExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is LogicException exception)
    {
      context.Result = new ObjectResult(new { error = exception.Message })
      {
        StatusCode = exception.StatusCode
      };
      context.ExceptionHandled = true;
    }
  }
}