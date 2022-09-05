using Microsoft.AspNetCore.Mvc.Filters;
using MyMovies.Api.Loggger;

namespace MyMovies.Api.Filters
{
    public class CustomActionFilterEndpoint : Attribute, IActionFilter
    {
        private readonly string verb;

        public CustomActionFilterEndpoint(string verb)
        {
            this.verb = verb;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<LogBase>();
            logger?.Log($"{verb}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
