using System;
using System.Web.Mvc;
using KeepFit.Core.Domain.Gym;
using KeepFit.Core.Services.Gym;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class GymController : BaseController
    {
        readonly GymService _gymService = new GymService();

        public ActionResult Index()
        {
            var model = new GymModel {Gyms = _gymService.GetGyms()};
            return View(model);
        }
        [HttpPost]
        public JsonResult AddGym(string name, string latitude, string longitude)
        {
            Gym gym = _gymService.AddGym(new Gym { Name = name, Latitude = Convert.ToDouble(latitude), Longitude = Convert.ToDouble(longitude) });
            return Json(gym);
        }
    }
}
