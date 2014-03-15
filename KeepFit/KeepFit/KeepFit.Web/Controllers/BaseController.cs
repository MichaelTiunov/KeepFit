using System.Web.Mvc;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new KeepFitPrincipal User
        {
            get { return HttpContext.User as KeepFitPrincipal; }
        }
    }
}