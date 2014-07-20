using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Results;
using BasicAuthentication.Model;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using WebApiAuth.Filters;

namespace WebApiAuth.Controllers
{
    [IdentityBasicAuthentication] // Enable authentication via an ASP.NET Identity user name and password
    [Authorize]
    public class HomeController : BaseController
    {
        private IBodyCompositionService bodyCompositionService;
        public HomeController(IAccountService accountService, IIdentityService identityService, IBodyCompositionService bodyCompositionService)
            : base(accountService, identityService)
        {
            this.bodyCompositionService = bodyCompositionService;
        }

        public JsonResult<List<BodyCompositionDto>> Get()
        {
            var compositions = bodyCompositionService.GetBodyCompositions(KeepFitIdentity.UserId).ToList();
            return Json(compositions);
        }
    }
}
