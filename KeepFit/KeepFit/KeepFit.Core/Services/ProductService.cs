using System.Data.Entity.Migrations;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class ProductService: IProductService
    {
        private readonly IKeepFitContext keepFitContext;

        public ProductService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public void AddProduct(Product product)
        {
            keepFitContext.Products.AddOrUpdate(product);
            keepFitContext.SaveChanges();
        }
    }
}
