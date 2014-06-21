using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeepFit.Core.Models;

namespace KeepFit.Core.Dto
{
    public class ProductDto
    {
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

        public IEnumerable<ProductType> ProductTypes { get; set; } 
    }
}
