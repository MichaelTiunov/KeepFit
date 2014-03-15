using System.Linq;
using System.Security.Principal;

namespace KeepFit.Web.Models
{
    public class KeepFitPrincipal:IPrincipal
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }

        public bool IsInRole(string role)
        {
            return Roles.Any(x => x.Contains(role));
        }

        public IIdentity Identity { get; private set; }
    }
}