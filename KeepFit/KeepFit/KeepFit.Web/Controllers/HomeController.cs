using System;
using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAccountService accountService, IIdentityService identityService)
            : base(accountService, identityService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public PartialViewResult CaloriesCalculation()
        {
            var model = new CaloriesCalculationModel();
            return PartialView(model);
        }
    }
}