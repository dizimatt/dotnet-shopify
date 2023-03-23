using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Services.ProductService
{
    public interface IProductService
    {
        List<Product> getAllProducts();
        Product GetProductById(int id);
        List<Product> AddProduct(Product newProduct);
    }
}