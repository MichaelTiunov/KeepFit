using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IBodyCompositionService bodyCompositionService;
        //
        // GET: /Profile/
        public ProfileController(IAccountService accountService, IIdentityService identityService, IBodyCompositionService bodyCompositionService)
            : base(accountService, identityService)
        {
            this.bodyCompositionService = bodyCompositionService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}