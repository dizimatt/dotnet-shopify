using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Services.ProductService
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>{
            new Product{
                Id = 0
            },
            new Product { 
                Id = 1,
                Title = "Second DotNet Product",
                Status = ProductStatus.Active
            }
        };

        public async Task<ServiceResponse<List<Product>>> AddProduct(Product newProduct)
        {
            var serviceResponse = new ServiceResponse<List<Product>>();
            products.Add(newProduct);
            serviceResponse.Data = products;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Product>>> getAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();
            serviceResponse.Data = products;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<Product>();
            var product = products.FirstOrDefault(c => c.Id == id);
//            if (product is null)
//                throw new Exception("Product not found");
            serviceResponse.Data = product;
            return serviceResponse;
        }
    }
}