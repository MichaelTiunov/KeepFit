using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeepFit.Web.Models
{
    public interface IIdentityService
    {
        KeepFitIdentity KeepFitIdentity { get; }
    }
}