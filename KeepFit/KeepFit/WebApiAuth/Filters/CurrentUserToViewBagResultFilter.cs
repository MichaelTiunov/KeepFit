using System.Web.Mvc;
using KeepFit.Web.Identity;

namespace WebApiAuth.Filters
{
    public class CurrentUserToViewBagResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var identity = filterContext.RequestContext.HttpContext.User.Identity as KeepFitIdentity;

            if (identity != null)
            {
                filterContext.Controller.ViewBag.CurrentUser = identity;
            }
        }
    }
}