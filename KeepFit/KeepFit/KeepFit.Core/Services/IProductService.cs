using System.Collections;
using System.Collections.Generic;
using KeepFit.Core.Models;

namespace KeepFit.Core.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts();
    }
}
