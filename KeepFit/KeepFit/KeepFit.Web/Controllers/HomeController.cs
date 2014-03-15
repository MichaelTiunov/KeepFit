using System.Linq;
using System.Web.Mvc;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class HomeController : BaseController
    {
        KeepFitContext context = new KeepFitContext();
        public ActionResult Index()
        {
            var users = context.Users.Where(x => x.UserId == 1).ToList();
            return View(users);
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
    }
}