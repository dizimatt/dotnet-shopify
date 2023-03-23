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

        private readonly IMapper _mapper;

        public ProductService(IMapper mapper){
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var product = _mapper.Map<Product>(newProduct);
            product.Id = products.Max(c => c.Id) + 1;
            products.Add(product);
            serviceResponse.Data = products.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> getAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            serviceResponse.Data = products.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            var product = products.FirstOrDefault(c => c.Id == id);
//            if (product is null)
//                throw new Exception("Product not found");
            serviceResponse.Data = _mapper.Map<GetProductDto>(product);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            var product = products.FirstOrDefault(c => c.Id == updatedProduct.Id);

            if (product is not null){

                if (updatedProduct.Title is not null)
                    product.Title = updatedProduct.Title;
                if (updatedProduct.Vendor is not null)
                    product.Vendor = updatedProduct.Vendor;
                if (updatedProduct.ProductType is not null)
                    product.ProductType = updatedProduct.ProductType;
                if (updatedProduct.TemplateSuffix is not null)
                    product.TemplateSuffix = updatedProduct.TemplateSuffix;
                if (updatedProduct.ImageId is not null)
                    product.ImageId = updatedProduct.ImageId;
                if (updatedProduct.Status is not null)
                    product.Status = (ProductStatus)updatedProduct.Status;
                
                products.Add(product);

                serviceResponse.Data = _mapper.Map<GetProductDto>(product);
            } else {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found";
            }

            return serviceResponse;
        }
    }
}