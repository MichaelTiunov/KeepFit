using System.Collections.Generic;
using KeepFit.Core.Dto;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProductService
    {
        void AddOrUpdateProduct(ProductDto product);
        void AddProductType(ProductTypeDto product);
        ProductDto GetProduct(int productId);
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<Product> GetProductsByType(int typeId);
    }
}
