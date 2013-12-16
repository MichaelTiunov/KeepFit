using System.Web.Mvc;
using KeepFit.Models;

namespace KeepFit.Controllers
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
