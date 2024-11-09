using System.Net;
using System.Text.Json;
using Application.Exceptions;

namespace Presentation.Middlewares;

public class ExceptionMiddleware(IEnumerable<IExceptionHandler> handlers, RequestDelegate next)
{
  private readonly IEnumerable<IExceptionHandler> _handlers = handlers;
  private readonly RequestDelegate _next = next;
  private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

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

  private async Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    if (context.Response.HasStarted) return;

    context.Response.ContentType = "application/json";
    var handler = _handlers.FirstOrDefault(h => h.CanHandle(exception));
    if (handler != null)
    {
      var response = handler.Handle(context, exception);
      await WriteContext(context, response);
    }
    else
    {
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      var response = new ErrorResponse 
      {
        Title = "An internal server error occurred",
        Message = exception.Message
      };
      await WriteContext(context, response);
    }
  }

  private async Task WriteContext(HttpContext context, ErrorResponse response)
    => await context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonOptions));
}