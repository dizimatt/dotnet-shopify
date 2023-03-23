using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shopify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
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

        [HttpGet("GetAll")]
        public ActionResult<List<Product>> Get() 
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetSingle(int id)
        {
            return Ok(products.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product newProduct)
        {
            products.Add(newProduct);
            return Ok(products);
        }
    }
}