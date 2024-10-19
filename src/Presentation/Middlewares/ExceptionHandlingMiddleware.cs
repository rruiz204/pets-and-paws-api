using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
  private readonly RequestDelegate _next = next;
  public async Task InvokeAsync(HttpContext httpContext)
  {
    try
    {
      await _next(httpContext);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(httpContext, ex);
    }
  }

  public async Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";
    var payload = new ProblemDetails();

    switch (exception)
    {
      case ValidationException ex:
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        payload.Title = "One or more validation errors occurred";

        var errors = ex.Errors
          .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
          .ToDictionary(fg => fg.Key, fg => fg.ToArray());

        payload.Extensions.Add("errors", errors);
        break;

      default:
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        payload.Title = "An unexpected error occurred";
        payload.Detail = exception.Message;
        break;
    }

    var response = JsonSerializer.Serialize(payload);
    await context.Response.WriteAsync(response);
  }
}