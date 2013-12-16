using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeepFit.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebGrease.Css.Extensions;

namespace VK.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private IEnumerable<Ingredient> ing = new List<Ingredient>
        {
            new Ingredient
            {
                Name = "Apple",
                Id=1
            },
            new Ingredient
            {
                Name = "Orange",
                Id = 2
            },
            new Ingredient
            {
                Name = "Potato",
                Id=3
            }
        };

        public JsonResult GetIngredients(string q)
        {
            var ingredients = ing.Where(i => i.Name.ToLower().Contains(q));

            return JsonNet(ingredients);
        }

        private IEnumerable<Recept> rec = new List<Recept>
        {
            new Recept
            {
                Name = "Bulba",
               Ingredients = new[] {new Ingredient
               {
                   Name = "Potato",
                   Id=3
               }}
            }
        };
        public JsonResult FindRecept(IEnumerable<string> ingredients)
        {
            return JsonNet(ingredients);
        }

        protected static JsonResult JsonNet(object responseBody)
        {
            return new JsonNetResult(responseBody, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
        }

        public JsonNetResult(object responseBody)
        {
            this.ResponseBody = responseBody;
        }

        public JsonNetResult(object responseBody, JsonSerializerSettings settings)
        {
            this.ResponseBody = responseBody;
            this.Settings = settings;
        }

        /// <summary>
        /// Gets or sets the serialiser settings.
        /// </summary> 
        public JsonSerializerSettings Settings { get; set; }

        /// <summary>
        /// Gets or sets the body of the response.
        /// </summary> 
        public object ResponseBody { get; set; }

        /// <summary>
        /// Gets the formatting types depending on whether we are in debug mode.
        /// </summary> 
        private Formatting Formatting
        {
            get
            {
                return Debugger.IsAttached ? Formatting.Indented : Formatting.None;
            }
        }

        /// <summary> 
        /// Serialises the response and writes it out to the response object 
        /// </summary> 
        /// <param name="context">The execution context</param> 
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;

            // set content type 
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            // set content encoding 
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.ResponseBody != null)
            {
                response.Write(JsonConvert.SerializeObject(this.ResponseBody, this.Formatting, this.Settings));
            }
        }
    }
}
