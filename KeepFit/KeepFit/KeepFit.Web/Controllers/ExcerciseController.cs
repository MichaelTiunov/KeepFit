using System.Linq;
using System.Web.Mvc;
using KeepFit.Core.Dto;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class ExcerciseController : BaseController
    {
        private readonly IExcerciseService excerciseService;
        private readonly IProductService productService;
        public ExcerciseController(IAccountService accountService, IIdentityService identityService, IExcerciseService excerciseService, IProductService productService)
            : base(accountService, identityService)
        {
            this.excerciseService = excerciseService;
            this.productService = productService;
        }

        public ActionResult Index()
        {
            //Get();
            var model = new ExcercisesModel
            {
                ExcerciseCategories = excerciseService.GetCategories(),
                Excercises = excerciseService.GetExcercises()
            };
            return View(model);
        }

        public ViewResult AddExcerciseCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExcerciseCategory(ExcerciseCategoryDto productType)
        {
            if (ModelState.IsValid)
            {
                excerciseService.AddOrUpdateExcerciseCategory(productType);
            }
            return RedirectToAction("Index");
        }

        public ViewResult AddExcercise()
        {
            var excerciseDto = new ExcerciseDto
            {
                ExcerciseCategories = excerciseService.GetCategories()
            };
            return View(excerciseDto);
        }

        [HttpPost]
        public ActionResult AddExcercise(ExcerciseDto product)
        {
            if (ModelState.IsValid)
            {
                excerciseService.AddOrUpdateExcercise(product);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditExcercise(int id)
        {
            var excercise = excerciseService.GetExcercise(id);
            excercise.ExcerciseCategories = excerciseService.GetCategories();
            return View(excercise);
        }
        [HttpPost]
        public ActionResult EditExcercise(ExcerciseDto excerciseDto)
        {
            if (ModelState.IsValid)
            {
                excerciseService.AddOrUpdateExcercise(excerciseDto);
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetExcercises(int typeId)
        {
            var products = excerciseService.GetExcercises(typeId).ToList();
            return Json(products);
        }

        //private void Get()
        //{
        //    string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Work\KeepFit\KeepFit\KeepFit\KeepFit.Web\App_Data\baz.mdb";
        //    using (OleDbConnection connection = new OleDbConnection(connectionString))
        //    {
        //        // The insertSQL string contains a SQL statement that
        //        // inserts a new row in the source table.
        //        OleDbCommand command = new OleDbCommand("Select * from pitanie");

        //        // Set the Connection to the new OleDbConnection.
        //        command.Connection = connection;

        //        // Open the connection and execute the insert command.
        //        try
        //        {
        //            connection.Open();
        //            var reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                double caloricVal = 0;
        //                double carbohydrates = 0;
        //                double proteins = 0;
        //                double fats = 0;
        //                int typeId = 0;
        //                var excerciseDto = new Product
        //                {
        //                    Name = reader[2].ToString(),
        //                    CaloricValue = double.TryParse(reader[3].ToString(), out caloricVal) ? caloricVal : 0,
        //                    Carbohydrates = double.TryParse(reader[6].ToString(), out carbohydrates) ? carbohydrates : 0,
        //                    Fats = double.TryParse(reader[4].ToString(), out fats) ? fats : 0,
        //                    Proteins = double.TryParse(reader[5].ToString(), out proteins) ? proteins : 0,
        //                    ProductTypeId = int.TryParse(reader[1].ToString(), out typeId) ? typeId : 1
        //                };
        //                productService.AddOrUpdateProduct(excerciseDto);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        // The connection is automatically closed when the
        //        // code exits the using block.
        //    }
        //}
    }
}
