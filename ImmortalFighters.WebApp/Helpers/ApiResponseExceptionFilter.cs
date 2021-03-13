using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImmortalFighters.WebApp.Helpers
{
    public class ApiResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ApiResponseException exception)
            {
                context.Result = new ObjectResult(exception.ClientMessage)
                {
                    StatusCode = exception.StatusCode
                };
                context.ExceptionHandled = true;
            }

        }
    }
}
