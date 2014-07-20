using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApiAuth.Data;

namespace WebApiAuth.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        private readonly IAccountService accountService;

        public IdentityBasicAuthenticationAttribute()
        {
            this.accountService = new AccountService(new KeepFitContext(), new SecurityService());
        }
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var user = accountService.GetUserByUserName(userName);
            KeepFitPrincipal keepFitPrincipal = null;
            switch (accountService.CheckCredintials(user, password))
            {
                case CheckCredentialsResultType.NoPasswordHasBeenSetUp:
                    break;
                case CheckCredentialsResultType.InvalidCredentials:
                    break;
                case CheckCredentialsResultType.Ok:
                    keepFitPrincipal = new KeepFitPrincipal(user.UserId, user.UserId, user.Username, user.Individual.FirstName, user.Individual.LastName, RoleType.Admin, "keepfit");
                    break;
            }
            Thread.CurrentPrincipal = HttpContext.Current.User = keepFitPrincipal;
            return keepFitPrincipal;
        }
    }
}