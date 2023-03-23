using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
        }
    }
}