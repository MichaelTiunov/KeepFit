using System.Collections.Generic;
using System.Web.Http;
using KeepFit.Core.Dto;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using WebApiAuth.Filters;

namespace WebApiAuth.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    public class ManagementController : BaseController
    {
        private readonly IBodyCompositionService bodyCompositionService;

        public ManagementController(IAccountService accountService, IIdentityService identityService, IBodyCompositionService bodyCompositionService)
            : base(accountService, identityService)
        {
            this.bodyCompositionService = bodyCompositionService;
        }

        public IEnumerable<BodyCompositionDto> Get()
        {
            return bodyCompositionService.GetBodyCompositions(KeepFitIdentity.UserId);
        }
    }
}
