using System;
using System.ComponentModel;
using System.Web.Mvc;
using KeepFit.Models;

namespace KeepFit.Controllers
{
    [Authorize]
    public class BodyController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DailyStatistic(string weight, BodyStatistic model)
        {
            var x = 10;
            return Json(model);
        }
    }

    public class CustomModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.Name == "Weight")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["weight"]);
                return;
            }
            if (propertyDescriptor.Name == "Growth")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["growth"]);
                return;
            }
            if (propertyDescriptor.Name == "Waistline")
            {
                propertyDescriptor.SetValue(bindingContext.Model,
                    controllerContext.HttpContext.Request.Form["waistline"]);
                return;
            }
            if (propertyDescriptor.Name == "Chest")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["chest"]);
                return;
            }
            if (propertyDescriptor.Name == "Neck")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["neck"]);
                return;
            }
            if (propertyDescriptor.Name == "Shoulders")
            {
                propertyDescriptor.SetValue(bindingContext.Model,
                    controllerContext.HttpContext.Request.Form["shoulders"]);
                return;
            }
            if (propertyDescriptor.Name == "Forearms")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["forearms"]);
                return;
            }
            if (propertyDescriptor.Name == "Calves")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["calves"]);
                return;
            }
            if (propertyDescriptor.Name == "Thighs")
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.Form["thighs"]);
                return;
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }

    }
}
