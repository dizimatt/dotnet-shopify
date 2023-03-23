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
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> Get() 
        {
            return Ok(await(_productService.getAllProducts()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingle(int id)
        {
            return Ok(await(_productService.GetProductById(id)));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto newProduct)
        {
            return Ok(await(_productService.AddProduct(newProduct)));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct(UpdateProductDto udpatedProduct)
        {
            var response = await(_productService.UpdateProduct(udpatedProduct));
            if (response.Success){
                return Ok(response);
            } else {
                return this.BadRequest(response);
            }
        }
    }
}