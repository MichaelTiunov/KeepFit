using System.Web.Mvc;

namespace KeepFit.Controllers
{
    public class GymController : BaseController
    {
        //
        // GET: /Gym/

        public ActionResult Index()
        {
            return View();
        }
    }
}
