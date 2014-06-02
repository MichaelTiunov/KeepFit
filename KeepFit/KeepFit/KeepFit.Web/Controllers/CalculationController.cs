using System;
using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class CalculationController : BaseController
    {
        // GET: Calculation
        public CalculationController(IAccountService accountService, IIdentityService identityService)
            : base(accountService, identityService)
        {
        }

        public ActionResult Index()
        {
            var model = new CalculationModel
            {
                CaloriesCalculationModel = new CaloriesCalculationModel()
            };
            return View(model);
        }
        [HttpPost]
        public JsonResult CaloriesCalculation(CaloriesCalculationModel model)
        {
            if (ModelState.IsValid)
            {
                double bmr;
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


                Session["BMR"] = Math.Round(bmr);

                return Json(new
                {
                    bmr = Math.Round(bmr)
                });
            }
            return Json(new { });

        }

        [HttpPost]
        public JsonResult ImtCalculation(CaloriesCalculationModel model)
        {
            if (ModelState.IsValid)
            {
                double r = model.Height / 100;
                double imt = model.Weight / Math.Pow(r, 2);
                imt = Math.Round(imt, 2);
                string z = "";
                if (imt <= 16)
                {
                    z = "Выраженный дефицит массы тела";
                }
                if ((imt >= 16) && (imt < 18.5))
                {
                    z = "Недостаточная (дефицит) масса тела";
                }
                if ((imt >= 18.5) && (imt < 25))
                {
                    z = "Норма";
                }
                if ((imt >= 25) && (imt <= 30))
                {
                    z = "Избыточная масса тела (предожирение)";
                }
                if ((imt >= 30) && (imt <= 35))
                {
                    z = "Ожирение первой степени";
                }
                if ((imt >= 35) && (imt <= 40))
                {
                    z = "Ожирение второй степени";
                }
                if (imt > 40)
                {
                    z = "Ожирение третьей степени (морбидное)";
                }
                var znach = z;

                return Json(new
                {
                    imt = Math.Round(imt, 1),
                    result = znach
                });
            }
            return Json(new { });

        }
    }
}