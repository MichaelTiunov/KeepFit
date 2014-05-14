using System.Web.Mvc;
using KeepFit.Core.Services;
using KeepFit.Web.Models;
using KeepFit.Web.Models.Nutrition;

namespace KeepFit.Web.Controllers
{
    public class NutritionController : BaseController
    {
        private readonly IProductService productService;

        public NutritionController(IAccountService accountService, IIdentityService identityService, IProductService productService)
            : base(accountService, identityService)
        {
            this.productService = productService;
        }
        public ActionResult Index()
        {
            var model = new NutritionModel
            {
                Products = productService.GetProducts()
            };
            return View(model);
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}