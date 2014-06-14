using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;
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

        public ActionResult EditProduct(int id)
        {
            return View();
        }
        public ActionResult Product(int id)
        {
            return View();
        }

        public ViewResult AddProduct()
        {
            var productDto = new ProductDto
            {
                ProductTypes = productService.GetProductTypes()
            };
            return View(productDto);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                productService.AddProduct(product);
            }
            return RedirectToAction("Products");
        }
        public ActionResult Products()
        {
            var types = productService.GetProductTypes();
            var productTypes = types as IList<ProductType> ?? types.ToList();
            var productModel = new ProductsModel
            {
                ProductTypes = productTypes,
                Products = productService.GetProductsByType(productTypes.First().ProductTypeId)
            };
            return View(productModel);
        }
        [HttpPost]
        public JsonResult GetProducts(int typeId)
        {
            var products = productService.GetProductsByType(typeId);
            return Json(products);
        }
    }
}