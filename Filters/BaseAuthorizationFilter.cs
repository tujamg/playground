using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthPlayGround.Filters
{
    public abstract class BaseAuthorizationFilterImp : IAsyncAuthorizationFilter
    {
        protected BaseAuthorizationFilterImp(string logger)
        {
            Console.WriteLine($"Inside BaseAuth: {logger}");
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            context.HttpContext.Items.Add($"{"EXECUTE_ITEM_PREFIX"}{GetType().Name}", "EXECUTE_ITEM_PREFIX");
            if (ShouldSkipFilter(context))
            {
                return;
            }

            await OnAuthorizationInternalAsync(context);
        }

        protected abstract Task OnAuthorizationInternalAsync(AuthorizationFilterContext context);

        private bool ShouldSkipFilter(AuthorizationFilterContext context)
        {
            return context.HttpContext.Items.Any(item => ((string)item.Key).StartsWith("ERROR_"));
        }

        protected void UpdateErrorInContext(
            AuthorizationFilterContext context,
            HttpStatusCode httpStatusCode = HttpStatusCode.Unauthorized,
            string rawErrorMsg = null,
            HttpStatusCodeException e = null)
        {
            var errorMsg = string.IsNullOrEmpty(rawErrorMsg) ? httpStatusCode.ToString() : rawErrorMsg;
            throw e ?? new HttpStatusCodeException(httpStatusCode, errorMsg);
        }

        protected void UpdateErrorInContext(AuthorizationFilterContext context, HttpStatusCodeException e)
        {
            UpdateErrorInContext(context, HttpStatusCode.Unauthorized, e.Message, e);
        }
    }
}
