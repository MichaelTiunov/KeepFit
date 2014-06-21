using System.Collections.Generic;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProductService
    {
        void AddProduct(ProductDto product);
        void AddProductType(ProductTypeDto product);
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<Product> GetProductsByType(int typeId);
    }
}
