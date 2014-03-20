using System.Web.Mvc;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IIdentityService identityService = new IdentityService();

        public BaseController()
        {
        }

        protected virtual new KeepFitPrincipal User
        {
            get { return HttpContext.User as KeepFitPrincipal; }
        }
        internal KeepFitIdentity KeepFitIdentity
        {
            get { return identityService.KeepFitIdentity; }
        }
    }
}