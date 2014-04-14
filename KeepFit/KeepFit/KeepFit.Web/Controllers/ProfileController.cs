using System.Web.Mvc;
using KeepFit.Core.Dto;
using KeepFit.Core.Services;
using KeepFit.Web.Models;
using KeepFit.Web.Models.Profile;

namespace KeepFit.Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IBodyCompositionService bodyCompositionService;
        private readonly IProgressPhotoService progressPhotoService;
        //
        // GET: /Profile/
        public ProfileController(IAccountService accountService,
            IIdentityService identityService,
            IBodyCompositionService bodyCompositionService,
            IProgressPhotoService progressPhotoService)
            : base(accountService, identityService)
        {
            this.bodyCompositionService = bodyCompositionService;
            this.progressPhotoService = progressPhotoService;
        }

        public ActionResult Index()
        {
            var model = new ProfileModel
            {
                ProgressPhoto = new ProgressPhotoModel
                {
                    ProgressPhotos = progressPhotoService.GetProgressPhotos(KeepFitIdentity.UserId)
                }
            };
            return View(model);
        }

        public ViewResult AddBodyComposition(BodyCompositionDto model)
        {
            bodyCompositionService.SaveBodyComposition(model.Height, model.Weight, KeepFitIdentity.UserId);
            return View("Index");
        }
    }
}