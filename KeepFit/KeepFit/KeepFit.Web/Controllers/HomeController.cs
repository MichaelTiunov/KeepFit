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
        [HttpPost]
        public JsonResult CaloriesCalculation(CaloriesCalculationModel model)
        {
            double bmr = 0;
            double imt = 0;
            if (ModelState.IsValid)
            {
                if (model.Gender == Gender.Male)
                {
                    bmr = 88.36 + (13.4 * model.Weight) + (4.8 * model.Height) - (5.7 * model.Age);
                }
                else
                {
                    bmr = 447.6 + (9.2 * model.Weight) + (3.1 * model.Height) - (4.3 * model.Age);
                }
                switch (model.ActivityType)
                {
                    case ActivityType.Minimum:
                        bmr += 1.2;
                        break;
                    case ActivityType.Low:
                        bmr *= 1.375;
                        break;
                    case ActivityType.Middle:
                        bmr *= 1.55;
                        break;
                    case ActivityType.Hight:
                        bmr *= 1.75;
                        break;
                    case ActivityType.VeryHight:
                        bmr *= 1.9;
                        break;
                }

                double r = model.Height / 100;

                imt = model.Weight / Math.Pow(r, 2);
                imt = Math.Round(imt, 2);
                string z = "";
                if (imt < 15)
                {
                    z = "Îñòðûé äåôèöèò âåñà";
                }
                if ((imt >= 15) && (imt < 20))
                {
                    z = "Äåôèöèò âåñà";
                }
                if ((imt >= 20) && (imt < 25))
                {
                    z = "Íîðìàëüíûé âåñ";
                }
                if ((imt >= 25) && (imt <= 30))
                {
                    z = "Èçáûòî÷íûé âåñ";
                }
                if (imt > 30)
                {
                    z = "Îæèðåíèå";
                }
               var znach = z;

                Session["BMR"] = Math.Round(bmr);
                Session["IMT"] = Math.Round(imt, 1);

                return Json(new
                {
                    bmr = Math.Round(bmr),
                    imt = Math.Round(imt, 1)
                });
            }
            return Json(new { });

        }
    }
}