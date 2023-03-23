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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Product>> Get() 
        {
            return Ok(_productService.getAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetSingle(int id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product newProduct)
        {
            return Ok(_productService.AddProduct(newProduct));
        }
    }
}