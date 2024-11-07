using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters;

public class ResponseFormatterFilter : ActionFilterAttribute
{
  public override void OnActionExecuted(ActionExecutedContext context)
  {
    var original = context.Result as ObjectResult;
    var template = new { data = original?.Value };
    context.Result = new ObjectResult(template);
    base.OnActionExecuted(context);
  }
}