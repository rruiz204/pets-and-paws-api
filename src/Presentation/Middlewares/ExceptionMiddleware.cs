using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
  private readonly RequestDelegate _next = next;
  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(context, ex);
    }
  }

  private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";
    var payload = new ProblemDetails();

    switch (exception)
    {
      case ValidationException ex:
        HandleValidationException(context, payload, ex);
        break;
      case InvalidDataException ex:
        HandleCommonException(context, payload, ex, (int)HttpStatusCode.NotFound);
        break;
      default:
        HandleCommonException(context, payload, exception, (int)HttpStatusCode.InternalServerError);
        break;
    }

    var response = JsonSerializer.Serialize(payload);
    await context.Response.WriteAsync(response);
  }

  private static void HandleValidationException(HttpContext context, ProblemDetails payload, ValidationException ex)
  {
    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    payload.Title = "One or more validation errors occurred";

    var errors = ex.Errors
      .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
      .ToDictionary(fg => fg.Key, fg => fg.ToArray());

    payload.Extensions.Add("errors", errors);
  }

  private static void HandleCommonException(HttpContext context, ProblemDetails payload, Exception ex, int statusCode)
  {
    context.Response.StatusCode = statusCode;
    payload.Title = ex.Message;
  }
}