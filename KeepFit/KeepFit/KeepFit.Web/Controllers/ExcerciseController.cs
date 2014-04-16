using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class ExcerciseController : BaseController
    {
        private readonly IExcerciseService excerciseService;
        public ExcerciseController(IAccountService accountService, IIdentityService identityService, IExcerciseService excerciseService)
            : base(accountService, identityService)
        {
            this.excerciseService = excerciseService;
        }

        public ActionResult Index()
        {
            var model = new ExcercisesModel
            {
                ExcerciseCategories = excerciseService.GetCategories(),
                Excercises = excerciseService.GetExcercises()
            };
            return View(model);
        }
    }
}