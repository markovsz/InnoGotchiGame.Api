using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    public class ExtractUserIdFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var userIdClaim = context.HttpContext.User.Claims
                .Where(c => c.Type.Equals(ClaimTypes.NameIdentifier))
                .FirstOrDefault();
            Guid userId;
            Guid.TryParse(userIdClaim.Value, out userId);
            context.ActionArguments.Add("userId", userId); /*!*/
        }
    }
}
