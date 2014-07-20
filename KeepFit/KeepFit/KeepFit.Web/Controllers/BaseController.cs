using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IIdentityService identityService;
        protected readonly IAccountService accountService;

        public BaseController(IAccountService accountService,IIdentityService identityService)
        {
            this.accountService = accountService;
            this.identityService = identityService;
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