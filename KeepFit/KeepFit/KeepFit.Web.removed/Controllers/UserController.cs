using System.Web.Mvc;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            var model = new UserModel();

            return View(model);
        }

        public ActionResult Calculate(UserModel model)
        {
            return View("Index");
        }
    }
}
