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

        public List<Product> AddProduct(Product newProduct)
        {
            products.Add(newProduct);
            return products;
        }

        public List<Product> getAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault(c => c.Id == id);
            if (product is not null)
                return product;

            throw new Exception("Character not found");
        }
    }
}