using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
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
        public void AddOrUpdateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                ProductId = productDto.ProductId,
                Name = productDto.Name,
                CaloricValue = productDto.CaloricValue,
                Proteins = productDto.Proteins,
                Carbohydrates = productDto.Carbohydrates,
                Fats = productDto.Fats,
                ProductTypeId = productDto.ProductTypeId,
            };
            if (productDto.ProductPhoto != null && productDto.ProductPhoto.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(productDto.ProductPhoto.InputStream))
                {
                    byte[] array = binaryReader.ReadBytes(productDto.ProductPhoto.ContentLength);
                    var base64File = Convert.ToBase64String(array);
                    product.ProductPhoto = base64File;
                }
            }
            keepFitContext.Products.AddOrUpdate(product);
            keepFitContext.SaveChanges();
        }

        public void AddProductType(ProductTypeDto productTypeDto)
        {
            var productType = new ProductType
            {
                Name = productTypeDto.Name,
                Description = productTypeDto.Description
            };

            keepFitContext.ProductTypes.AddOrUpdate(productType);
            keepFitContext.SaveChanges();
        }

        public ProductDto GetProduct(int productId)
        {
            return keepFitContext.Products.Where(x => x.ProductId == productId).Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                Name = x.Name,
                CaloricValue = x.CaloricValue,
                Proteins = x.Proteins,
                Carbohydrates = x.Carbohydrates,
                Fats = x.Fats,
                ProductTypeId = x.ProductTypeId,
            }).FirstOrDefault();
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
