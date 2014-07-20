using System.Web;
using System.Web.Http;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers.api
{
    public class BaseWebApiController : ApiController
    {
        private readonly IIdentityService identityService;
        protected readonly IAccountService accountService;

        public BaseWebApiController(IAccountService accountService, IIdentityService identityService)
        {
            this.accountService = accountService;
            this.identityService = identityService;
        }

        protected virtual new KeepFitPrincipal User
        {
            get
            {
                var context = Request.Properties["MS_HttpContext"] as HttpContextWrapper;
                if (context != null) return
                    context.User as KeepFitPrincipal;
                return null;
            }
        }
        internal KeepFitIdentity KeepFitIdentity
        {
            get { return identityService.KeepFitIdentity; }
        }
    }
}
