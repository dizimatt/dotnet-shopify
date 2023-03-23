using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace shopify.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> getAllProducts();
        Task<ServiceResponse<GetProductDto>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct);
    }
}