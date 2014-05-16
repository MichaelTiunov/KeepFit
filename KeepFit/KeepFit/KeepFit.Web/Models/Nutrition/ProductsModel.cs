using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Web.Models.Nutrition
{
    public class ProductsModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}