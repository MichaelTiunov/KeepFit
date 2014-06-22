using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using KeepFit.Core.Models;

namespace KeepFit.Core.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Display(Name = "Калорийность")]
        public double CaloricValue { get; set; }
        [Display(Name = "Белки")]
        public double Proteins { get; set; }
        [Display(Name = "Жиры")]
        public double Fats { get; set; }
        [Display(Name = "Углеводы")]
        public double Carbohydrates { get; set; }
        [Display(Name = "Категория")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Фото")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ProductPhoto { get; set; }

        public IEnumerable<ProductType> ProductTypes { get; set; } 
    }
}
