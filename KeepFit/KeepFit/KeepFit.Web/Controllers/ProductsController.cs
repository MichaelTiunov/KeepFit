using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KeepFit.Core.Domain.Product;

namespace KeepFit.Web.Controllers
{
    public class ProductsController : Web.Controllers.BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Product> ing = new List<Product>
        {
            new Product
            {
                Name = "Apple",
                Id=1
            },
            new Product
            {
                Name = "Orange",
                Id = 2
            },
            new Product
            {
                Name = "Potato",
                Id=3
            }
        };

        public JsonResult GetIngredients(string term)
        {
            var ingredients = ing.Where(i => i.Name.ToLower().Contains(term));

            return JsonNet(ingredients);
        }
    }
}
