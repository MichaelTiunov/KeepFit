using System.Web;

namespace KeepFit.Web.Identity
{
    public class IdentityService : IIdentityService
    {
        public KeepFitIdentity KeepFitIdentity
        {
            get
            {
                return HttpContext.Current.User.Identity as KeepFitIdentity;
            }
        }
    }
}