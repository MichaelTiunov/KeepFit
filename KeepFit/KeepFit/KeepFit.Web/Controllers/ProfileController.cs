using System;
using System.IO;
using System.Web;
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

        [HttpPost]
        public ActionResult AddBodyComposition(BodyCompositionDto model)
        {
            bodyCompositionService.SaveBodyComposition(model.Height, model.Weight, KeepFitIdentity.UserId);
            return RedirectToAction("BodyWeight");
        }

        public ActionResult ProgressPhotos()
        {
            var photosModel = new ProgressPhotoModel
            {
                ProgressPhotos = progressPhotoService.GetProgressPhotos(KeepFitIdentity.UserId)
            };
            return View(photosModel);
        }
        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    byte[] array = binaryReader.ReadBytes(file.ContentLength);
                    var base64File = Convert.ToBase64String(array);
                    progressPhotoService.SaveProgressPhoto(KeepFitIdentity.UserId, base64File);
                }
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("ProgressPhotos");
        }

        public ActionResult BodyWeight()
        {
            var model = new BodyWeightModel
            {
                BodyComposition = new BodyCompositionDto(),
                BodyCompositions = bodyCompositionService.GetBodyCompositions(KeepFitIdentity.UserId)
            };
            return View(model);
        }


    }
}