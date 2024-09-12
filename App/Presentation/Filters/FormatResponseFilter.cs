using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pets_And_Paws_Api.App.Presentation.Filters;

public class FormatResponseFilter : IActionFilter
{
  public void OnActionExecuting(ActionExecutingContext context) { }

  public void OnActionExecuted(ActionExecutedContext context)
  {
    if (context.Result is ObjectResult result && result.Value != null)
    {
      context.Result = new OkObjectResult(new { data = result.Value });
    }
  }
}