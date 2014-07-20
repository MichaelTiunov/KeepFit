using System.Collections.Generic;
using System.Linq;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers.api
{
    public class ManagementController : BaseWebApiController
    {
        private readonly IBodyCompositionService bodyCompositionService;
        public ManagementController(IAccountService accountService, IIdentityService identityService, IBodyCompositionService bodyCompositionService)
            : base(accountService, identityService)
        {
            this.bodyCompositionService = bodyCompositionService;
        }

        public IEnumerable<BodyComposition> Get()
        {
            return bodyCompositionService.GetBodyCompositions(KeepFitIdentity.UserId);
        }
        public BodyComposition Get(int id)
        {
            return bodyCompositionService.GetBodyCompositions(KeepFitIdentity.UserId).FirstOrDefault(x => x.BodyCompositionId == id);
        }
    }
}
