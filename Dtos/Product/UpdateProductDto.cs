using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Dtos.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Vendor { get; set; }
        public String? ProductType { get; set; }
        public String? TemplateSuffix { get; set; }
        public ProductStatus? Status { get; set; }
        public int? ImageId { get; set; }
    }
}