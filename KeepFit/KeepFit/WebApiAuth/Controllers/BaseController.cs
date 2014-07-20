using System.Web;
using System.Web.Http;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;

namespace WebApiAuth.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IIdentityService identityService;
        protected readonly IAccountService accountService;

        public BaseController(IAccountService accountService, IIdentityService identityService)
        {
            this.accountService = accountService;
            this.identityService = identityService;
        }

        protected virtual new KeepFitPrincipal User
        {
            get { return HttpContext.Current.User as KeepFitPrincipal; }
        }
        internal KeepFitIdentity KeepFitIdentity
        {
            get { return identityService.KeepFitIdentity; }
        }
    }
}
