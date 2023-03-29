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
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext context){
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            
            var product = _mapper.Map<Product>(newProduct);
//            product.Id = await _context.Products.MaxAsync(c => c.Id) + 1;
            await _context.Products.AddAsync(product);

            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            try{
                var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

                if (dbProduct is not null){
                    await _context.Products.ExecuteDeleteAsync();
                    serviceResponse.Success = true;

                    var dbProducts = await _context.Products.ToListAsync();
                    serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
                } else {
                    throw new Exception ($"Cannot locate Product with ID: '{id}', please check your product delete parameter");
                }
            } catch(Exception e){
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"exeption: {e.Message}";
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();
            var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
//            if (product is null)
//                throw new Exception("Product not found");
            serviceResponse.Data = _mapper.Map<GetProductDto>(dbProduct);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            try{
                var dbProduct = await _context.Products.FirstOrDefaultAsync(c => c.Id == updatedProduct.Id);

                if (dbProduct is not null){

                    if (updatedProduct.Title is not null)
                        dbProduct.Title = updatedProduct.Title;
                    if (updatedProduct.Vendor is not null)
                        dbProduct.Vendor = updatedProduct.Vendor;
                    if (updatedProduct.ProductType is not null)
                        dbProduct.ProductType = updatedProduct.ProductType;
                    if (updatedProduct.TemplateSuffix is not null)
                        dbProduct.TemplateSuffix = updatedProduct.TemplateSuffix;
                    if (updatedProduct.ImageId is not null)
                        dbProduct.ImageId = updatedProduct.ImageId;
                    if (updatedProduct.Status is not null)
                        dbProduct.Status = (ProductStatus)updatedProduct.Status;
                    
                    await _context.Products.AddAsync(dbProduct);
//                    products.Add(product);

                    serviceResponse.Success = true;
                    serviceResponse.Data = _mapper.Map<GetProductDto>(dbProduct);
                } else {
                    throw new Exception ($"Cannot locate Product with ID: '{updatedProduct.Id}', please check your product update payload");
                }
            } catch(Exception e){
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"exeption: {e.Message}";
            }

            return serviceResponse;
        }
    }
}