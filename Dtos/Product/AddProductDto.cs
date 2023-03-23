using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopify.Dtos.Product
{
    public class AddProductDto
    {
        public String Title { get; set; } = "New DotNet Product";
        public String? Vendor { get; set; }
        public String? ProductType { get; set; }
        public String? TemplateSuffix { get; set; }
        public int? ImageId { get; set; }
    }
}