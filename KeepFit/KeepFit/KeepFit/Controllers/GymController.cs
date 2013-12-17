using System.Web.Mvc;
using KeepFit.Core.Domain.Gym;
using KeepFit.Core.Services.Gym;

namespace KeepFit.Controllers
{
    public class GymController : BaseController
    {
        readonly GymService service = new GymService();

        public ActionResult Index()
        {
            service.AddGym(new Gym());
            return View();
        }
    }
}
