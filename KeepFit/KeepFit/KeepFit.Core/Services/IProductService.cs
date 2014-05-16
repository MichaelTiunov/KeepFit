using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void AddProductType(ProductType product);
        IEnumerable<Product> GetProducts();
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<Product> GetProductsByType(int typeId);
    }
}
