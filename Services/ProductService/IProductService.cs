using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> getAllProducts();
        Task<ServiceResponse<Product>> GetProductById(int id);
        Task<ServiceResponse<List<Product>>> AddProduct(Product newProduct);
    }
}