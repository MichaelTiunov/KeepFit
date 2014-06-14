using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IKeepFitContext keepFitContext;

        public ProductService(IKeepFitContext keepFitContext)
        {
            this.keepFitContext = keepFitContext;
        }
        public void AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                CaloricValue = productDto.CaloricValue,
                Proteins = productDto.Proteins,
                Carbohydrates = productDto.Carbohydrates,
                Fats = productDto.Fats,
                ProductTypeId = productDto.ProductTypeId
            };
            keepFitContext.Products.AddOrUpdate(product);
            keepFitContext.SaveChanges();
        }

        public void AddProductType(ProductType product)
        {
            keepFitContext.ProductTypes.AddOrUpdate(product);
            keepFitContext.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return keepFitContext.Products;
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return keepFitContext.ProductTypes;
        }

        public IEnumerable<Product> GetProductsByType(int typeId)
        {
            return keepFitContext.Products.Where(x => x.ProductTypeId == typeId);
        }
    }
}
