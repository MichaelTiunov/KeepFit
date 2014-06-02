using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepFit.Web.Models
{
    internal class IdentityService : IIdentityService
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